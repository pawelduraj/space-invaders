using System;
using System.Linq;
using SpaceInvaders.Game.Enemies;
using SpaceInvaders.Game.Listeners;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.Core;

public class Updater
{
    private readonly Engine _engine;
    private int _playerShipMissileCooldown, _freezeCooldown, _score, _level;
    private bool _gameOver;

    public Updater(Engine engine) => _engine = engine;

    public void Update()
    {
        _engine.LevelTextBlock.Text = $"Level: {_level}";
        _engine.ScoreTextBlock.Text = $"Score: {_score}";

        if (_freezeCooldown > 0) _freezeCooldown--;
        if (_freezeCooldown != 0) return;

        _engine.CenterTextBlock.Text = "";
        _engine.BasePlayerShip.Unlock();
        _engine.Enemies.ForEach(enemy => enemy.Unlock());

        if (KeyboardListener.IsSpacePressed() && _playerShipMissileCooldown == 0)
        {
            var playerShipBounds = _engine.BasePlayerShip.GetBounds();
            var missile = new Missile(new Coords(playerShipBounds.X + 22, playerShipBounds.Y), 12, 1);
            _engine.Missiles.Add(missile);
            _playerShipMissileCooldown = (int)(40 / _engine.BasePlayerCharacter.GetFireRateFactor());
            AudioPlayer.PlayShotSound();
        }

        if (_engine.BasePlayerShip.CanUseAbility())
            _engine.BasePlayerShip.UseAbility(this, _level);

        var enemyMissiles = _engine.Enemies.Select(enemy => enemy.CreateMissileOrNot())
            .Where(enemyMissile => enemyMissile != null).ToList();
        _engine.Missiles.AddRange(enemyMissiles!);

        if (_engine.Enemies.Exists(enemy => enemy.GetBounds().X is > 1510 or < 20))
            _engine.Enemies.ForEach(enemy => enemy.ChangeDirection());

        var mySuccessfulMissiles = _engine.Missiles
            .Where(missile => missile.GetDirection() == 1 && _engine.Enemies.Any(enemy => enemy.IsColliding(missile)))
            .ToList();

        var enemiesHit = _engine.Enemies.Where(enemy => mySuccessfulMissiles.Any(missile => missile.IsColliding(enemy)))
            .ToList();

        mySuccessfulMissiles.ForEach(missile => _engine.Missiles.Remove(missile));
        enemiesHit.ForEach(enemy => enemy.RemoveLive());
        enemiesHit = enemiesHit.Where(enemy => enemy.GetLives() == 0).ToList();
        enemiesHit.ForEach(enemy =>
            _score += (int)(_engine.BasePlayerCharacter.GetExperienceFactor() * enemy.GetScore()));
        enemiesHit.ForEach(enemy => _engine.Enemies.Remove(enemy));

        var enemiesCollidingShip = _engine.Enemies.Where(enemy => enemy.IsColliding(_engine.BasePlayerShip)).ToList();
        var missilesCollidingShip = _engine.Missiles
            .Where(missile => missile.GetDirection() == -1 && missile.IsColliding(_engine.BasePlayerShip)).ToList();

        if (enemiesCollidingShip.Count > 0 || missilesCollidingShip.Count > 0)
        {
            if (!_engine.BasePlayerShip.IsTouchable())
            {
                missilesCollidingShip.ForEach(missile => _engine.Missiles.Remove(missile));
            }
            else if (_engine.BasePlayerShip.HasShield())
            {
                missilesCollidingShip.ForEach(missile => _engine.Missiles.Remove(missile));
                _engine.BasePlayerShip.RemoveShield();
            }
            else if (_engine.BasePlayerShip.GetLives() > 1)
            {
                _engine.BasePlayerShip.RemoveLive();
                _engine.BasePlayerShip.TeleportTo(776, 700);
                _engine.BasePlayerShip.Lock();
                _engine.Enemies.ForEach(enemy => enemy.Lock());
                _engine.Missiles.Clear();
                _freezeCooldown = 120;
                AudioPlayer.PlayCrashSound();
            }
            else
            {
                HighScores.SetLastScore(_score);
                _gameOver = true;
                AudioPlayer.PlayCrashSound();
            }
        }

        if (_playerShipMissileCooldown > 0) _playerShipMissileCooldown--;

        if (_engine.Enemies.Count == 0) LoadLevel(_level + 1);
    }

    public void LoadLevel(int level)
    {
        _gameOver = false;
        _level = level;
        _score = level == 1 ? 0 : _score;
        _engine.CenterTextBlock.Text = "Level " + level;
        _freezeCooldown = 120;
        _engine.BasePlayerShip.TeleportTo(776, 700);
        _engine.BasePlayerShip.Lock();

        var enemies = Enumerable.Range(0, 60).Select(_ => new EnemyCustom(level)).ToList();
        for (var i = 0; i < 60; i++) enemies[i].TeleportTo(210 + 80 * (i % 15), 100 + 80 * (i / 15));
        _engine.Enemies.Clear();
        _engine.Enemies.AddRange(enemies);
        _engine.Missiles.Clear();
    }

    public bool IsGameOver()
    {
        return _gameOver;
    }

    public void KillRandomEnemy()
    {
        if (_engine.Enemies.Count == 0) return;
        var randomId = Random.Shared.Next(0, _engine.Enemies.Count);
        _engine.Enemies[randomId].RemoveLive();
        if (_engine.Enemies[randomId].GetLives() == 0)
            _engine.Enemies.RemoveAt(randomId);
    }

    public void DestroyRandomMissile()
    {
        var enemyMissiles = _engine.Missiles.Where(missile => missile.GetDirection() == -1).ToList();
        if (enemyMissiles.Count == 0) return;
        _engine.Missiles.Remove(enemyMissiles[Random.Shared.Next(0, enemyMissiles.Count)]);
    }
}