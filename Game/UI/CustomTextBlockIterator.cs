using System.Collections;
using System.Collections.Generic;

namespace SpaceInvaders.Game.UI;

public class CustomTextBlockIterator : IEnumerable<CustomTextBlock>
{
    private readonly MainMenu _mainMenu;

    internal CustomTextBlockIterator(MainMenu mainMenu) => _mainMenu = mainMenu;

    public IEnumerator<CustomTextBlock> GetEnumerator()
    {
        yield return _mainMenu.PlayerShipName;
        yield return _mainMenu.PlayerCharacterName;
        yield return _mainMenu.PlayerShipDescription;
        yield return _mainMenu.PlayerCharacterDescription;
        yield return _mainMenu.ScoreDescription;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
