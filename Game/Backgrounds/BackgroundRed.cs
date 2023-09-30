using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.Backgrounds;

public class BackgroundRed : Background
{
    public BackgroundRed()
    {
        Speed = 5;
        ImageBrush = ImageLoader.LoadBackground(2);
    }
}