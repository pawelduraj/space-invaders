using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerCharacters;

public class PlayerCharacterDavid : PlayerCharacter
{
    public PlayerCharacterDavid()
    {
        SpeedFactor = 1.0;
        ExperienceFactor = 1.0;
        AdditionalHealth = 0;
        FireRateFactor = 2.0;
        PlayerCharacterImages[0] = ImageLoader.LoadPlayerCharacter(2, 0);
        PlayerCharacterImages[1] = ImageLoader.LoadPlayerCharacter(2, 1);
        PlayerCharacterImages[2] = ImageLoader.LoadPlayerCharacter(2, 2);
        PlayerCharacterImages[3] = ImageLoader.LoadPlayerCharacter(2, 3);
        PlayerCharacterImages[4] = ImageLoader.LoadPlayerCharacter(2, 4);
    }
}