using System;
using SpaceInvaders.Game.Core;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerShips;

public class PlayerShipCovenant : PlayerShip
{
    public PlayerShipCovenant()
    {
        ImageLeft = ImageLoader.LoadPlayerShip(2, -1);
        ImageForward = ImageLoader.LoadPlayerShip(2, 0);
        ImageRight = ImageLoader.LoadPlayerShip(2, 1);
        AbilityCooldown = 120;
    }

    public override bool CanUseAbility()
    {
        return AbilityCooldown <= 0;
    }

    public override void UseAbility(Updater updater, int level)
    {
        updater.DestroyRandomMissile();
        AbilityCooldown = 120 - Math.Min(30, 3 * level);
    }
}