using System.Windows.Controls;

namespace SpaceInvaders.Game.UI;

public class PrintVisitor
{
    private readonly Canvas _canvas;

    public PrintVisitor(Canvas canvas) => _canvas = canvas;

    public void Print(ClickableImage clickableImage)
    {
        _canvas.Children.Add(clickableImage.GetImage());
        Canvas.SetLeft(clickableImage.GetImage(), clickableImage.X);
        Canvas.SetTop(clickableImage.GetImage(), clickableImage.Y);
    }

    public void Print(CustomTextBlock customTextBlock)
    {
        _canvas.Children.Add(customTextBlock);
        Canvas.SetLeft(customTextBlock, customTextBlock.Left);
        Canvas.SetTop(customTextBlock, customTextBlock.Top);
    }
}