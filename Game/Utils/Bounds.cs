namespace SpaceInvaders.Game.Utils;

public readonly struct Bounds
{
    public readonly int X, Y;
    private readonly int _width, _height;

    public Bounds(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        _width = width;
        _height = height;
    }

    public Bounds(Coords coords, int width, int height)
    {
        X = coords.X;
        Y = coords.Y;
        _width = width;
        _height = height;
    }

    public bool Intersects(Bounds other)
    {
        return X < other.X + other._width && X + _width > other.X &&
               Y < other.Y + other._height && Y + _height > other.Y;
    }
}