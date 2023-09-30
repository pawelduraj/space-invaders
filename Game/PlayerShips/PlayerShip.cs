using System;
using System.Windows.Controls;
using SpaceInvaders.Game.Core;
using SpaceInvaders.Game.Interfaces;
using SpaceInvaders.Game.Listeners;
using SpaceInvaders.Game.PlayerCharacters;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerShips;

public abstract class PlayerShip : ITick, IPrint, ICollide
{
    private Coords _cords = new(776, 700);
    private int _position;
    private int _speed = 6;
    private bool _shield;
    private int _lives = 3;
    private bool _locked;
    private bool _untouchable;
    protected int AbilityCooldown;

    protected Image ImageLeft = new();
    protected Image ImageForward = new();
    protected Image ImageRight = new();
    private readonly Image[] _imageHearts = new Image[5];
    private readonly Image _imageShield = ImageLoader.LoadMisc(1);
    private readonly Image _imageUntouchable = ImageLoader.LoadMisc(2);

    protected PlayerShip()
    {
        for (var i = 0; i < _imageHearts.Length; i++)
            _imageHearts[i] = ImageLoader.LoadMisc(0);
    }

    public void ApplyBonuses(PlayerCharacter playerCharacter)
    {
        for (var i = playerCharacter.GetAdditionalHealth(); i > 0; i--) AddLive();
        SetSpeed((int)(GetSpeed() * playerCharacter.GetSpeedFactor()));
    }

    public void TeleportTo(int x, int y)
    {
        _cords.X = x;
        _cords.Y = y;
        _position = 0;
    }

    public void SetSpeed(int speed)
    {
        _speed = speed;
    }

    public int GetSpeed()
    {
        return _speed;
    }

    public void AddShield()
    {
        _shield = true;
    }

    public void RemoveShield()
    {
        _shield = false;
    }

    public bool HasShield()
    {
        return _shield;
    }

    public void AddLive()
    {
        _lives++;
    }

    public void RemoveLive()
    {
        _lives--;
    }

    public int GetLives()
    {
        return _lives;
    }

    public void Lock()
    {
        _locked = true;
    }

    public void Unlock()
    {
        _locked = false;
    }

    public bool IsLocked()
    {
        return _locked;
    }

    public void MakeTouchable()
    {
        _untouchable = false;
    }

    public void MakeUntouchable()
    {
        _untouchable = true;
    }

    public bool IsTouchable()
    {
        return !_untouchable;
    }

    public abstract bool CanUseAbility();

    public abstract void UseAbility(Updater updater, int level);

    public void Tick()
    {
        if (_locked || _lives <= 0) return;
        if (KeyboardListener.IsUpPressed())
            _cords.Y = Math.Max(0, _cords.Y - _speed);
        if (KeyboardListener.IsDownPressed())
            _cords.Y = Math.Min(812, _cords.Y + _speed);
        if (KeyboardListener.IsLeftPressed())
            _cords.X = Math.Max(0, _cords.X - _speed);
        if (KeyboardListener.IsRightPressed())
            _cords.X = Math.Min(1537, _cords.X + _speed);
        if (KeyboardListener.IsLeftPressed() && !KeyboardListener.IsRightPressed())
            _position = -1;
        else if (KeyboardListener.IsRightPressed() && !KeyboardListener.IsLeftPressed())
            _position = 1;
        else _position = 0;
        if (AbilityCooldown > 0) AbilityCooldown--;
    }

    public void Print(Canvas canvas)
    {
        if (_untouchable)
        {
            canvas.Children.Add(_imageUntouchable);
            Canvas.SetLeft(_imageUntouchable, _cords.X - 16);
            Canvas.SetTop(_imageUntouchable, _cords.Y - 16);
        }

        var shipImage = _position == 0 ? ImageForward : _position < 0 ? ImageLeft : ImageRight;
        canvas.Children.Add(shipImage);
        Canvas.SetLeft(shipImage, _cords.X);
        Canvas.SetTop(shipImage, _cords.Y);

        for (var i = 0; i < _lives; i++)
        {
            canvas.Children.Add(_imageHearts[i]);
            Canvas.SetLeft(_imageHearts[i], 100 + 40 * i);
            Canvas.SetTop(_imageHearts[i], 10);
        }


        if (!_shield) return;
        canvas.Children.Add(_imageShield);
        Canvas.SetLeft(_imageShield, 100);
        Canvas.SetTop(_imageShield, 50);
    }

    public bool IsColliding(ICollide other)
    {
        return GetBounds().Intersects(other.GetBounds());
    }

    public Bounds GetBounds()
    {
        return new Bounds(_cords, 48, 48);
    }
}