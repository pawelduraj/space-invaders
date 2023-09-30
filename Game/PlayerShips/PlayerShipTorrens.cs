using System;
using SpaceInvaders.Game.Core;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.PlayerShips;

public class PlayerShipTorrens : PlayerShip
{
    public PlayerShipTorrens()
    {
        ImageLeft = ImageLoader.LoadPlayerShip(1, -1);
        ImageForward = ImageLoader.LoadPlayerShip(1, 0);
        ImageRight = ImageLoader.LoadPlayerShip(1, 1);
        AbilityCooldown = 1400;
    }

    public override bool CanUseAbility()
    {
        if (AbilityCooldown > 240) MakeTouchable();
        else MakeUntouchable();
        return AbilityCooldown <= 0;
    }

    public override void UseAbility(Updater updater, int level)
    {
        AbilityCooldown = Math.Max(400, 1400 - level * 16);
    }
}