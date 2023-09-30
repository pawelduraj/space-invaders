using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerCharacters;

public class PlayerCharacterAlien : PlayerCharacter
{
    public PlayerCharacterAlien()
    {
        SpeedFactor = 1.5;
        ExperienceFactor = 0.5;
        AdditionalHealth = 2;
        FireRateFactor = 2.0;
        PlayerCharacterImages[0] = ImageLoader.LoadPlayerCharacter(3, 0);
        PlayerCharacterImages[1] = ImageLoader.LoadPlayerCharacter(3, 1);
        PlayerCharacterImages[2] = ImageLoader.LoadPlayerCharacter(3, 2);
        PlayerCharacterImages[3] = ImageLoader.LoadPlayerCharacter(3, 3);
        PlayerCharacterImages[4] = ImageLoader.LoadPlayerCharacter(3, 4);
    }
}