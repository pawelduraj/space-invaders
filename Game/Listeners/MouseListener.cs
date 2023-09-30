using System.Windows;
using System.Windows.Input;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.Listeners;

public static class MouseListener
{
    private static bool IsHover(Bounds bounds)
    {
        var point = Mouse.GetPosition(Application.Current.MainWindow);
        return bounds.Intersects(new Bounds((int)point.X, (int)point.Y, 1, 1));
    }

    public static bool IsClicked(Bounds bounds) => IsHover(bounds) && Mouse.LeftButton == MouseButtonState.Pressed;
    public static bool IsReleased() => Mouse.LeftButton == MouseButtonState.Released;
    public static int GetX() => (int)Mouse.GetPosition(Application.Current.MainWindow).X;
    public static int GetY() => (int)Mouse.GetPosition(Application.Current.MainWindow).Y;
}