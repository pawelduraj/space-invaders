using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SpaceInvaders.Game.UI;

public class TextBlockBuilder
{
    private string _text = "";
    private int _fontSize = 20;
    private string _foregroundColor = "#FFFFFF";
    private string _backgroundColor = "";
    private int _padding;
    private bool _alignCenter;
    private bool _wrapText;
    private int _width = 100;
    private int _height = 25;
    private int _left;
    private int _top;

    private static readonly BrushConverter BrushConverter = new();

    public CustomTextBlock Build() => new()
    {
        Text = _text,
        FontSize = _fontSize,
        Foreground = (Brush)BrushConverter.ConvertFromString(_foregroundColor)!,
        Background = _backgroundColor != "" ? (Brush)BrushConverter.ConvertFromString(_backgroundColor)! : null,
        Padding = new Thickness(_padding),
        TextAlignment = _alignCenter ? TextAlignment.Center : TextAlignment.Left,
        TextWrapping = _wrapText ? TextWrapping.Wrap : TextWrapping.NoWrap,
        Width = _width,
        Height = _height,
        Left = _left,
        Top = _top
    };

    public void SetText(string text) => _text = text;
    public void SetFontSize(int fontSize) => _fontSize = fontSize;
    public void SetForegroundColor(string foregroundColor) => _foregroundColor = foregroundColor;
    public void SetBackgroundColor(string backgroundColor) => _backgroundColor = backgroundColor;
    public void SetPadding(int padding) => _padding = padding;
    public void SetAlignCenter(bool alignCenter) => _alignCenter = alignCenter;
    public void SetWrapText(bool wrapText) => _wrapText = wrapText;
    public void SetWidth(int width) => _width = width;
    public void SetHeight(int height) => _height = height;

    public void SetCords(int left, int top)
    {
        _left = left;
        _top = top;
    }
}

public class CustomTextBlock : TextBlock
{
    public int Left { get; init; }
    public int Top { get; init; }
}