using System.Windows.Input;

namespace SpaceInvaders.Game.Listeners;

public static class KeyboardListener
{
    public static bool IsLeftPressed()
    {
        return Keyboard.IsKeyDown(Key.Left) && !Keyboard.IsKeyDown(Key.Right);
    }

    public static bool IsUpPressed()
    {
        return Keyboard.IsKeyDown(Key.Up) && !Keyboard.IsKeyDown(Key.Down);
    }

    public static bool IsRightPressed()
    {
        return Keyboard.IsKeyDown(Key.Right) && !Keyboard.IsKeyDown(Key.Left);
    }

    public static bool IsDownPressed()
    {
        return Keyboard.IsKeyDown(Key.Down) && !Keyboard.IsKeyDown(Key.Up);
    }

    public static bool IsSpacePressed()
    {
        return Keyboard.IsKeyDown(Key.Space);
    }
}