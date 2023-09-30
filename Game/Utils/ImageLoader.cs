using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpaceInvaders.Game.Utils;

public static class ImageLoader
{
    public static ImageBrush LoadBackground(int id)
    {
        if (id is < 0 or > 2)
            throw new ArgumentOutOfRangeException(nameof(id), "id must be between 0 and 2");
        var imageBrush = LoadImageBrush("Backgrounds", id + 128 * id, 0, 128, 256);
        imageBrush.ViewportUnits = BrushMappingMode.Absolute;
        imageBrush.TileMode = TileMode.Tile;
        return imageBrush;
    }

    public static Image LoadButtonSquared(int id, int click)
    {
        if (id is < 0 or > 23)
            throw new ArgumentOutOfRangeException(nameof(id), "id must be between 0 and 23");
        if (click is < 0 or > 2)
            throw new ArgumentOutOfRangeException(nameof(click), "click must be between 0 and 2");
        return WithSize(LoadImage("UI", 88 + 36 * (id % 3) + id % 3 + 12 * click, 14 * (id / 3), 12, 14), 60, 70);
    }

    public static Image LoadEnemy(int id)
    {
        if (id is < 0 or > 35)
            throw new ArgumentOutOfRangeException(nameof(id), "id must be between 0 and 35");
        return WithSize(LoadImage("Ships", 32 + (id % 6) * 8, 8 * (id / 6), 8, 8), 48, 48);
    }

    public static Image LoadMisc(int id)
    {
        if (id is < 0 or > 2)
            throw new ArgumentOutOfRangeException(nameof(id), "id must be between 0 and 1");
        return id is 0 or 1
            ? WithSize(LoadImage("Miscellaneous", 16 + id * 8, 0, 8, 8), 32, 32)
            : WithSize(LoadImage("Miscellaneous", 88, 32, 16, 16), 80, 80);
    }

    public static Image LoadMissile(int id)
    {
        if (id is < 0 or > 1)
            throw new ArgumentOutOfRangeException(nameof(id), "id must be between 0 and 1");
        return id == 0
            ? WithSize(LoadImage("Projectiles", 4, 4, 1, 1), 4, 4)
            : WithSize(LoadImage("Projectiles", 27, 5, 1, 1), 4, 4);
    }

    public static Image LoadPlayerCharacter(int id, int position)
    {
        if (id is < 0 or > 10)
            throw new ArgumentOutOfRangeException(nameof(id), "id must be between 0 and 10");
        if (position is < 0 or > 4)
            throw new ArgumentOutOfRangeException(nameof(position), "position must be between 0 and 4");
        return WithSize(LoadImage("Characters", 1 + 8 * position, 8 * id, 8, 8), 80, 80);
    }

    public static Image LoadPlayerShip(int id, int position)
    {
        if (id is < 0 or > 4)
            throw new ArgumentOutOfRangeException(nameof(id), "id must be between 1 and 5");
        if (position is < -1 or > 1)
            throw new ArgumentOutOfRangeException(nameof(position), "position must be between -1 and 1");
        return WithSize(LoadImage("Ships", 8 + position * 8, 8 * id, 8, 8), 48, 48);
    }

    public static TextBlock LoadTextBlock(string text, int width, int height) => new()
    {
        Text = text,
        FontSize = 20,
        Foreground = Brushes.White,
        TextAlignment = TextAlignment.Center,
        TextWrapping = TextWrapping.Wrap,
        Width = width,
        Height = height
    };

    private static Image LoadImage(string group, int posX, int posY, int sizeX, int sizeY)
    {
        BitmapImage image = new(new Uri(@"pack://application:,,,/Game/Assets/" + group + ".png", UriKind.Absolute));
        CroppedBitmap croppedBitmap = new(image, new Int32Rect(posX, posY, sizeX, sizeY));
        return new Image { Source = croppedBitmap };
    }

    private static ImageBrush LoadImageBrush(string group, int posX, int posY, int sizeX, int sizeY)
    {
        BitmapImage image = new(new Uri(@"pack://application:,,,/Game/Assets/" + group + ".png", UriKind.Absolute));
        CroppedBitmap croppedBitmap = new(image, new Int32Rect(posX, posY, sizeX, sizeY));
        return new ImageBrush { ImageSource = croppedBitmap };
    }

    private static Image WithSize(Image image, int width, int height)
    {
        image.Width = width;
        image.Height = height;
        return image;
    }
}