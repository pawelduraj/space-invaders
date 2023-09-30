using System;
using SpaceInvaders.Game.Backgrounds;
using SpaceInvaders.Game.PlayerCharacters;
using SpaceInvaders.Game.PlayerShips;

namespace SpaceInvaders.Game.Utils;

public static class Loader
{
    public static Background GetBackground(int id)
    {
        return id switch
        {
            0 => new BackgroundDefault(),
            1 => new BackgroundNight(),
            2 => new BackgroundRed(),
            _ => throw new ArgumentOutOfRangeException(nameof(id))
        };
    }

    public static PlayerCharacter GetPlayerCharacter(int id)
    {
        return id switch
        {
            0 => new PlayerCharacterEllenRipley(),
            1 => new PlayerCharacterElizabethShaw(),
            2 => new PlayerCharacterBishop(),
            3 => new PlayerCharacterDavid(),
            4 => new PlayerCharacterAlien(),
            _ => throw new ArgumentOutOfRangeException(nameof(id))
        };
    }

    public static string GetPlayerCharacterName(int id)
    {
        return id switch
        {
            0 => "Ellen Ripley",
            1 => "Elizabeth Shaw",
            2 => "Bishop",
            3 => "David",
            4 => "Alien",
            _ => throw new ArgumentOutOfRangeException(nameof(id))
        };
    }

    public static string GetPlayerCharacterDescription(int id)
    {
        return id switch
        {
            0 => "\"This is Ripley, last survivor of the Nostromo, signing off.\"\n" +
                 "Move speed: 1.5\nExperience: 1.0\nExtra health: 0\nFire rate: 1.0",
            1 => "\"They created us. Then they tried to kill us.\"\n" +
                 "Move speed: 1.0\nExperience: 2.0\nExtra health: 0\nFire rate: 1.0",
            2 => "\"I may be synthetic, but I'm not stupid.\"\n" +
                 "Move speed: 1.0\nExperience: 1.0\nExtra health: 2\nFire rate: 1.0",
            3 => "\"Big things have small beginnings.\"\n" +
                 "Move speed: 1.0\nExperience: 1.0\nExtra health: 0\nFire rate: 1.5",
            4 => "\"If you see a xeno, you do one thing: run.\"\n" +
                 "Move speed: 1.5\nExperience: 0.5\nExtra health: 2\nFire rate: 1.5",
            _ => throw new ArgumentOutOfRangeException(nameof(id))
        };
    }

    public static PlayerShip GetPlayerShip(int id)
    {
        return id switch
        {
            0 => new PlayerShipNostromo(),
            1 => new PlayerShipPrometheus(),
            2 => new PlayerShipCovenant(),
            3 => new PlayerShipTorrens(),
            4 => new PlayerShipDerelict(),
            _ => throw new ArgumentOutOfRangeException(nameof(id))
        };
    }

    public static string GetPlayerShipName(int id)
    {
        return id switch
        {
            0 => "Nostromo",
            1 => "Prometheus",
            2 => "Covenant",
            3 => "Torrens",
            4 => "Derelict",
            _ => throw new ArgumentOutOfRangeException(nameof(id))
        };
    }

    public static string GetPlayerShipDescription(int id)
    {
        return id switch
        {
            0 => "This is commercial towing vehicle Nostromo out of the Solomons.\n" +
                 "Special ability: Gives extra health (up to 5)",
            1 => "It was a revolutionary starship, the most advanced and most expensive vehicle ever constructed.\n" +
                 "Special ability: Gives shield",
            2 => "You have all sacrificed so much to be here, to be a part of this.\n" +
                 "Special ability: Destroys random enemy missile",
            3 => "I had to take a lot of contracts to get her into shape, but now she more than pays for herself.\n" +
                 "Special ability: Becomes untouchable",
            4 => "It was a ship. Relatively intact it was, and more alien than any of them had imagined possible.\n" +
                 "Special ability: Deal damage to random enemy",
            _ => throw new ArgumentOutOfRangeException(nameof(id))
        };
    }
}