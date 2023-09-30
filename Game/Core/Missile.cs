using System.Windows.Controls;
using SpaceInvaders.Game.Interfaces;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.Core;

public class Missile : ITick, IPrint, ICollide
{
    private Coords _cords;
    private readonly int _speed;
    private readonly int _direction;
    private readonly Image _missileImage;

    public Missile(Coords cords, int speed, int direction)
    {
        _cords = cords;
        _speed = speed;
        _direction = direction;
        _missileImage = ImageLoader.LoadMissile(direction == 1 ? 0 : 1);
    }

    public int GetDirection()
    {
        return _direction;
    }
    
    public void Tick()
    {
        _cords.Y += _speed * -_direction;
    }

    public void Print(Canvas canvas)
    {
        canvas.Children.Add(_missileImage);
        Canvas.SetLeft(_missileImage, _cords.X);
        Canvas.SetTop(_missileImage, _cords.Y);
    }

    public bool IsColliding(ICollide other)
    {
        return GetBounds().Intersects(other.GetBounds());
    }

    public Bounds GetBounds()
    {
        return new Bounds(_cords, 4, 4);
    }
}