using System;
using System.Windows.Controls;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.UI;

public class ClickableImage
{
    private readonly Image _imageDefault, _imageHover, _imageClicked;
    internal readonly int X, Y;
    private int _state;

    public ClickableImage(int imageId, int x, int y)
    {
        _imageDefault = ImageLoader.LoadButtonSquared(imageId, 0);
        _imageHover = ImageLoader.LoadButtonSquared(imageId, 1);
        _imageClicked = ImageLoader.LoadButtonSquared(imageId, 2);
        X = x;
        Y = y;
    }

    public void Update(bool on, int x, int y)
    {
        if (on && x >= X && x <= X + _imageDefault.Width && y >= Y && y <= Y + _imageDefault.Height)
            _state = 2;
        else if (x >= X && x <= X + _imageDefault.Width && y >= Y && y <= Y + _imageDefault.Height)
            _state = 1;
        else _state = 0;
    }

    public Image GetImage() => _state switch
    {
        0 => _imageDefault,
        1 => _imageHover,
        2 => _imageClicked,
        _ => throw new ArgumentOutOfRangeException()
    };

    public bool IsClicked() => _state == 2;
}