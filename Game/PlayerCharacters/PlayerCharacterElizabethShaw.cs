using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerCharacters;

public class PlayerCharacterElizabethShaw : PlayerCharacter
{
    public PlayerCharacterElizabethShaw()
    {
        SpeedFactor = 1.0;
        ExperienceFactor = 1.5;
        AdditionalHealth = 0;
        FireRateFactor = 1.0;
        PlayerCharacterImages[0] = ImageLoader.LoadPlayerCharacter(4, 0);
        PlayerCharacterImages[1] = ImageLoader.LoadPlayerCharacter(4, 1);
        PlayerCharacterImages[2] = ImageLoader.LoadPlayerCharacter(4, 2);
        PlayerCharacterImages[3] = ImageLoader.LoadPlayerCharacter(4, 3);
        PlayerCharacterImages[4] = ImageLoader.LoadPlayerCharacter(4, 4);
    }
}