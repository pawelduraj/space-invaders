using System;
using SpaceInvaders.Game.Core;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerShips;

public class PlayerShipNostromo : PlayerShip
{
    public PlayerShipNostromo()
    {
        ImageLeft = ImageLoader.LoadPlayerShip(3, -1);
        ImageForward = ImageLoader.LoadPlayerShip(3, 0);
        ImageRight = ImageLoader.LoadPlayerShip(3, 1);
        AbilityCooldown = 1400;
    }

    public override bool CanUseAbility()
    {
        return AbilityCooldown <= 0;
    }

    public override void UseAbility(Updater updater, int level)
    {
        if (GetLives() < 5) AddLive();
        AbilityCooldown = Math.Max(600, 1400 - level * 32);
    }
}