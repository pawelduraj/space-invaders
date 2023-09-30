using System.Collections;
using System.Collections.Generic;
using SpaceInvaders.Game.Interfaces;

namespace SpaceInvaders.Game.Core;

public class Ticker : IEnumerable<ITick>
{
    private readonly Engine _engine;

    internal Ticker(Engine engine) => _engine = engine;

    public IEnumerator<ITick> GetEnumerator()
    {
        yield return _engine.Background;
        foreach (var missile in _engine.Missiles)
            yield return missile;
        foreach (var enemy in _engine.Enemies)
            yield return enemy;
        yield return _engine.BasePlayerShip;
        yield return _engine.BasePlayerCharacter;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}