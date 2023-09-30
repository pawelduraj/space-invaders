using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.Backgrounds;

public class BackgroundNight : Background
{
    public BackgroundNight()
    {
        Speed = 4;
        ImageBrush = ImageLoader.LoadBackground(1);
    }
}