using System.Collections;
using System.Collections.Generic;

namespace SpaceInvaders.Game.UI;

public class ClickableImageIterator : IEnumerable<ClickableImage>
{
    private readonly MainMenu _mainMenu;

    internal ClickableImageIterator(MainMenu mainMenu) => _mainMenu = mainMenu;

    public IEnumerator<ClickableImage> GetEnumerator()
    {
        yield return _mainMenu.BackgroundChange;
        yield return _mainMenu.MusicChange;
        yield return _mainMenu.LeftPlayerShip;
        yield return _mainMenu.RightPlayerShip;
        yield return _mainMenu.LeftPlayerCharacter;
        yield return _mainMenu.RightPlayerCharacter;
        yield return _mainMenu.StartGame;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}