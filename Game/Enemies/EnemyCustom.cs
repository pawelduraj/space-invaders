using System;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.Enemies;

public class EnemyCustom : Enemy
{
    public EnemyCustom(int level)
    {
        level -= 1;
        Locked = true;
        Lives = Math.Min(20, 1 + level / 6);
        Speed = 1 + Math.Min(3, 4 + level / 3);
        MissileChance = Math.Min(0.02, 0.0008 + 0.0004 * level);
        MissileSpeed = Math.Min(80, 8 + level / 3);
        Score = 25 + level * 5;
        EnemyImage = ImageLoader.LoadEnemy(Math.Min(35, level / 3));
    }
}