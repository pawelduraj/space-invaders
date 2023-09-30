using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SpaceInvaders.Game.Backgrounds;
using SpaceInvaders.Game.Enemies;
using SpaceInvaders.Game.Interfaces;
using SpaceInvaders.Game.PlayerCharacters;
using SpaceInvaders.Game.PlayerShips;
using SpaceInvaders.Game.UI;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.Core;

public class Engine : ITick, IPrint
{
    private int _state;
    private readonly Ticker _ticker;
    private readonly Printer _printer;
    private readonly Updater _updater;
    private readonly MainMenu _mainMenu = new();

    internal Background Background = new BackgroundDefault();
    internal PlayerCharacter BasePlayerCharacter = new PlayerCharacterEllenRipley();
    internal PlayerShip BasePlayerShip = new PlayerShipNostromo();
    internal readonly List<Enemy> Enemies = new();
    internal readonly List<Missile> Missiles = new();

    internal readonly TextBlock CenterTextBlock = ImageLoader.LoadTextBlock("", 1600, 900);
    internal readonly TextBlock LevelTextBlock = ImageLoader.LoadTextBlock("Level: 1", 300, 30);
    internal readonly TextBlock ScoreTextBlock = ImageLoader.LoadTextBlock("Score: 0", 300, 30);

    public Engine()
    {
        _ticker = new Ticker(this);
        _printer = new Printer(this);
        _updater = new Updater(this);
    }

    public void Update()
    {
        switch (_state)
        {
            case 0:
                //_mainMenu.Update();
                if (_mainMenu.ReadyToStart()) InitializeGame();
                break;
            case 1:
                _updater.Update();
                if (_updater.IsGameOver()) _state = 0;
                break;
        }
    }

    public void Tick()
    {
        switch (_state)
        {
            case 0:
                _mainMenu.Tick();
                break;
            case 1:
                foreach (var tick in _ticker) tick.Tick();
                break;
        }
    }

    public void Print(Canvas canvas)
    {
        canvas.Children.Clear();
        switch (_state)
        {
            case 0:
                _mainMenu.Print(canvas);
                break;
            case 1:
                foreach (var print in _printer)
                    print.Print(canvas);
                PrintUiTexts(canvas);
                break;
        }
    }

    private void InitializeGame()
    {
        BasePlayerCharacter = Loader.GetPlayerCharacter(_mainMenu.GetPlayerCharacterIndex());
        BasePlayerShip = Loader.GetPlayerShip(_mainMenu.GetPlayerShipIndex());
        BasePlayerShip.ApplyBonuses(BasePlayerCharacter);
        Background = Loader.GetBackground(_mainMenu.GetBackgroundIndex());
        _updater.LoadLevel(1);
        _state = 1;
        _mainMenu.Reset();
    }

    private void PrintUiTexts(Panel canvas)
    {
        LevelTextBlock.TextAlignment = TextAlignment.Left;
        canvas.Children.Add(LevelTextBlock);
        Canvas.SetLeft(LevelTextBlock, 10);
        Canvas.SetTop(LevelTextBlock, 800);

        ScoreTextBlock.TextAlignment = TextAlignment.Left;
        canvas.Children.Add(ScoreTextBlock);
        Canvas.SetLeft(ScoreTextBlock, 10);
        Canvas.SetTop(ScoreTextBlock, 825);

        CenterTextBlock.FontSize = 300;
        canvas.Children.Add(CenterTextBlock);
        Canvas.SetLeft(CenterTextBlock, 0);
        Canvas.SetTop(CenterTextBlock, 300);
    }
}