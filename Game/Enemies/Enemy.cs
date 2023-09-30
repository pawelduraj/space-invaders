using System;
using System.Windows.Controls;
using SpaceInvaders.Game.Core;
using SpaceInvaders.Game.Interfaces;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.Enemies;

public abstract class Enemy : ITick, IPrint, ICollide
{
    private Coords _cords = new(500, 500);
    private int _direction = 1;
    protected bool Locked;
    protected int Lives;
    protected int Speed;
    protected double MissileChance;
    protected int MissileSpeed;
    protected int Score;
    protected Image EnemyImage = new();

    public void TeleportTo(int x, int y)
    {
        _cords.X = x;
        _cords.Y = y;
    }

    public void ChangeDirection()
    {
        _direction *= -1;
    }

    public void Lock()
    {
        Locked = true;
    }

    public void Unlock()
    {
        Locked = false;
    }

    public void RemoveLive()
    {
        Lives--;
    }

    public int GetLives()
    {
        return Lives;
    }

    public Missile? CreateMissileOrNot()
    {
        return !Locked && Random.Shared.NextDouble() <= MissileChance
            ? new Missile(new Coords(_cords.X + 23, _cords.Y + 42), MissileSpeed, -1)
            : null;
    }

    public int GetScore()
    {
        return Score;
    }

    public void Tick()
    {
        if (Locked) return;
        if (Lives > 0 && _direction > 0)
            _cords.X = Math.Min(1537, _cords.X + Speed);
        if (Lives > 0 && _direction < 0)
            _cords.X = Math.Max(0, _cords.X - Speed);
    }

    public void Print(Canvas canvas)
    {
        canvas.Children.Add(EnemyImage);
        Canvas.SetLeft(EnemyImage, _cords.X);
        Canvas.SetTop(EnemyImage, _cords.Y);
    }

    public bool IsColliding(ICollide other)
    {
        return GetBounds().Intersects(other.GetBounds());
    }

    public Bounds GetBounds()
    {
        return new Bounds(_cords.X, _cords.Y, 48, 48);
    }
}