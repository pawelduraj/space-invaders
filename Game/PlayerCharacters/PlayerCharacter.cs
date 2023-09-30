using System.Windows.Controls;
using SpaceInvaders.Game.Interfaces;

namespace SpaceInvaders.Game.PlayerCharacters;

public abstract class PlayerCharacter : ITick, IPrint
{
    protected double SpeedFactor;
    protected double ExperienceFactor;
    protected int AdditionalHealth;
    protected double FireRateFactor;
    private int _animationCounter;
    protected readonly Image[] PlayerCharacterImages = new Image[5];

    public double GetSpeedFactor() => SpeedFactor;
    public double GetExperienceFactor() => ExperienceFactor;
    public int GetAdditionalHealth() => AdditionalHealth;
    public double GetFireRateFactor() => FireRateFactor;

    public void StartAnimation()
    {
        if (_animationCounter <= 0) _animationCounter = 400;
    }

    public void Tick()
    {
        if (_animationCounter > 0) _animationCounter--;
    }

    public void Print(Canvas canvas)
    {
        var image = _animationCounter switch
        {
            <= 0 => PlayerCharacterImages[0],
            <= 100 => PlayerCharacterImages[4],
            <= 200 => PlayerCharacterImages[3],
            <= 300 => PlayerCharacterImages[2],
            _ => PlayerCharacterImages[1]
        };
        canvas.Children.Add(image);
        Canvas.SetLeft(image, 10);
        Canvas.SetTop(image, 10);
    }
}