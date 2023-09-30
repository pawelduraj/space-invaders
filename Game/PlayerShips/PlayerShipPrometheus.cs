using System;
using SpaceInvaders.Game.Core;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerShips;

public class PlayerShipPrometheus : PlayerShip
{
    public PlayerShipPrometheus()
    {
        ImageLeft = ImageLoader.LoadPlayerShip(0, -1);
        ImageForward = ImageLoader.LoadPlayerShip(0, 0);
        ImageRight = ImageLoader.LoadPlayerShip(0, 1);
        AbilityCooldown = 400;
    }

    public override bool CanUseAbility()
    {
        return AbilityCooldown <= 0;
    }

    public override void UseAbility(Updater updater, int level)
    {
        AddShield();
        AbilityCooldown = Math.Max(120, 400 - level * 16);
    }
}