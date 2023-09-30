using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.Interfaces;

public interface ICollide
{
    bool IsColliding(ICollide other);
    Bounds GetBounds();
}