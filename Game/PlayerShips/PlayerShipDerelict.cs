using System;
using SpaceInvaders.Game.Core;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerShips;

public class PlayerShipDerelict : PlayerShip
{
    public PlayerShipDerelict()
    {
        ImageLeft = ImageLoader.LoadPlayerShip(4, -1);
        ImageForward = ImageLoader.LoadPlayerShip(4, 0);
        ImageRight = ImageLoader.LoadPlayerShip(4, 1);
        AbilityCooldown = 900;
    }

    public override bool CanUseAbility()
    {
        return AbilityCooldown <= 0;
    }

    public override void UseAbility(Updater updater, int level)
    {
        if (GetBounds().X is < 100 or > 1450) return;
        updater.KillRandomEnemy();
        AbilityCooldown = Math.Max(300, 900 - level * 16);
    }
}