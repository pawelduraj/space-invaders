using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.Backgrounds;

public class BackgroundDefault : Background
{
    public BackgroundDefault()
    {
        Speed = 3;
        ImageBrush = ImageLoader.LoadBackground(0);
    }
}