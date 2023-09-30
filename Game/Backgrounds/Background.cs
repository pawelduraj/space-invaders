using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SpaceInvaders.Game.Interfaces;

namespace SpaceInvaders.Game.Backgrounds;

public abstract class Background : ITick, IPrint
{
    private int _position;
    protected int Speed;
    protected ImageBrush ImageBrush = new();

    public void Tick()
    {
        _position = (_position + Speed) % 512;
    }

    public void Print(Canvas canvas)
    {
        ImageBrush.Viewport = new Rect(0, _position, 256, 512);
        canvas.Background = ImageBrush;
    }
}