using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerCharacters;

public class PlayerCharacterEllenRipley : PlayerCharacter
{
    public PlayerCharacterEllenRipley()
    {
        SpeedFactor = 1.5;
        ExperienceFactor = 1.0;
        AdditionalHealth = 0;
        FireRateFactor = 1.0;
        PlayerCharacterImages[0] = ImageLoader.LoadPlayerCharacter(8, 0);
        PlayerCharacterImages[1] = ImageLoader.LoadPlayerCharacter(8, 1);
        PlayerCharacterImages[2] = ImageLoader.LoadPlayerCharacter(8, 2);
        PlayerCharacterImages[3] = ImageLoader.LoadPlayerCharacter(8, 3);
        PlayerCharacterImages[4] = ImageLoader.LoadPlayerCharacter(8, 4);
    }
}