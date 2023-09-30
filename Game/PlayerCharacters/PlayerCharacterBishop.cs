using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerCharacters;

public class PlayerCharacterBishop : PlayerCharacter
{
    public PlayerCharacterBishop()
    {
        SpeedFactor = 1.0;
        ExperienceFactor = 1.0;
        AdditionalHealth = 2;
        FireRateFactor = 1.0;
        PlayerCharacterImages[0] = ImageLoader.LoadPlayerCharacter(1, 0);
        PlayerCharacterImages[1] = ImageLoader.LoadPlayerCharacter(1, 1);
        PlayerCharacterImages[2] = ImageLoader.LoadPlayerCharacter(1, 2);
        PlayerCharacterImages[3] = ImageLoader.LoadPlayerCharacter(1, 3);
        PlayerCharacterImages[4] = ImageLoader.LoadPlayerCharacter(1, 4);
    }
}