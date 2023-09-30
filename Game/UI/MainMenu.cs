using System;
using System.Collections.Generic;
using System.Windows.Controls;
using SpaceInvaders.Game.Backgrounds;
using SpaceInvaders.Game.Interfaces;
using SpaceInvaders.Game.Listeners;
using SpaceInvaders.Game.Utils;

namespace SpaceInvaders.Game.UI;

public class MainMenu : ITick, IPrint
{
    private readonly CustomTextBlockIterator _customTextBlockIterator;
    private readonly ClickableImageIterator _clickableImageIterator;

    internal readonly ClickableImage BackgroundChange;
    internal readonly ClickableImage MusicChange;
    internal readonly ClickableImage LeftPlayerShip;
    internal readonly ClickableImage RightPlayerShip;
    internal readonly ClickableImage LeftPlayerCharacter;
    internal readonly ClickableImage RightPlayerCharacter;
    internal readonly ClickableImage StartGame;

    private readonly List<Image> _playerShips = new();
    private readonly List<Image> _playerCharacters = new();
    private readonly List<Background> _backgrounds = new();

    internal int _playerShipIndex, _playerCharacterIndex, _backgroundIndex;
    internal bool _readyToStart, _isHold, _playMusic;

    internal readonly CustomTextBlock PlayerShipName;
    internal readonly CustomTextBlock PlayerCharacterName;
    internal readonly CustomTextBlock PlayerShipDescription;
    internal readonly CustomTextBlock PlayerCharacterDescription;
    internal readonly CustomTextBlock ScoreDescription;

    private readonly List<ClickableImage> _subscribers = new();

    public MainMenu()
    {
        _customTextBlockIterator = new CustomTextBlockIterator(this);
        _clickableImageIterator = new ClickableImageIterator(this);


        // Load Clickable Images

        BackgroundChange = new ClickableImage(0, 20, 20);
        MusicChange = new ClickableImage(3, 20, 110);
        LeftPlayerShip = new ClickableImage(11, 600, 150);
        RightPlayerShip = new ClickableImage(10, 940, 150);
        LeftPlayerCharacter = new ClickableImage(11, 600, 400);
        RightPlayerCharacter = new ClickableImage(10, 940, 400);
        StartGame = new ClickableImage(1, 770, 650);

        Subscribe(BackgroundChange);
        Subscribe(MusicChange);
        Subscribe(LeftPlayerShip);
        Subscribe(RightPlayerShip);
        Subscribe(LeftPlayerCharacter);
        Subscribe(RightPlayerCharacter);
        Subscribe(StartGame);


        // Load Player Ships, Player Characters and Backgrounds

        _playerShips.Add(ImageLoader.LoadPlayerShip(3, 0));
        _playerShips.Add(ImageLoader.LoadPlayerShip(0, 0));
        _playerShips.Add(ImageLoader.LoadPlayerShip(2, 0));
        _playerShips.Add(ImageLoader.LoadPlayerShip(1, 0));
        _playerShips.Add(ImageLoader.LoadPlayerShip(4, 0));

        foreach (var playerShip in _playerShips)
        {
            playerShip.Width = 80;
            playerShip.Height = 80;
        }

        _playerCharacters.Add(ImageLoader.LoadPlayerCharacter(8, 0));
        _playerCharacters.Add(ImageLoader.LoadPlayerCharacter(4, 0));
        _playerCharacters.Add(ImageLoader.LoadPlayerCharacter(1, 0));
        _playerCharacters.Add(ImageLoader.LoadPlayerCharacter(2, 0));
        _playerCharacters.Add(ImageLoader.LoadPlayerCharacter(3, 0));

        _backgrounds.Add(new BackgroundDefault());
        _backgrounds.Add(new BackgroundNight());
        _backgrounds.Add(new BackgroundRed());


        // Build Text Blocks

        var textBlockBuilder = new TextBlockBuilder();

        textBlockBuilder.SetAlignCenter(true);
        textBlockBuilder.SetWidth(200);
        textBlockBuilder.SetHeight(30);

        textBlockBuilder.SetCords(700, 250);
        PlayerShipName = textBlockBuilder.Build();

        textBlockBuilder.SetCords(700, 500);
        PlayerCharacterName = textBlockBuilder.Build();

        textBlockBuilder.SetBackgroundColor("#5182FF");
        textBlockBuilder.SetAlignCenter(false);
        textBlockBuilder.SetWrapText(true);
        textBlockBuilder.SetPadding(3);
        textBlockBuilder.SetWidth(280);
        textBlockBuilder.SetHeight(190);

        textBlockBuilder.SetCords(1050, 150);
        PlayerShipDescription = textBlockBuilder.Build();

        textBlockBuilder.SetCords(1050, 400);
        PlayerCharacterDescription = textBlockBuilder.Build();

        textBlockBuilder.SetWrapText(false);
        textBlockBuilder.SetWidth(220);
        textBlockBuilder.SetHeight(64);

        textBlockBuilder.SetCords(100, 20);
        ScoreDescription = textBlockBuilder.Build();
    }

    public bool ReadyToStart()
    {
        return !_isHold && _readyToStart;
    }

    public int GetPlayerShipIndex()
    {
        return _playerShipIndex;
    }

    public int GetPlayerCharacterIndex()
    {
        return _playerCharacterIndex;
    }

    public int GetBackgroundIndex()
    {
        return _backgroundIndex;
    }

    public void Reset()
    {
        _readyToStart = false;
    }

    public void Update()
    {
    }

    public void Tick()
    {
        _backgrounds[_backgroundIndex].Tick();

        var on = !MouseListener.IsReleased();
        var x = MouseListener.GetX();
        var y = MouseListener.GetY();
        NotifyAll(on, x, y);

        if (MouseListener.IsReleased())
            _isHold = false;
        else if (_isHold == false)
        {
            if (BackgroundChange.IsClicked())
                _backgroundIndex = (_backgroundIndex + 1) % _backgrounds.Count;
            else if (MusicChange.IsClicked())
            {
                if (_playMusic) AudioPlayer.StopBackgroundMusic();
                else AudioPlayer.PlayBackgroundMusic();
                _playMusic = !_playMusic;
            }
            else if (LeftPlayerShip.IsClicked())
                _playerShipIndex = Math.Max(0, _playerShipIndex - 1);
            else if (RightPlayerShip.IsClicked())
                _playerShipIndex = Math.Min(_playerShips.Count - 1, _playerShipIndex + 1);
            else if (LeftPlayerCharacter.IsClicked())
                _playerCharacterIndex = Math.Max(0, _playerCharacterIndex - 1);
            else if (RightPlayerCharacter.IsClicked())
                _playerCharacterIndex = Math.Min(_playerCharacters.Count - 1, _playerCharacterIndex + 1);
            else if (StartGame.IsClicked())
                _readyToStart = true;

            _isHold = true;
        }
    }

    public void Print(Canvas canvas)
    {
        _backgrounds[_backgroundIndex].Print(canvas);

        PlayerShipName.Text = Loader.GetPlayerShipName(_playerShipIndex);
        PlayerCharacterName.Text = Loader.GetPlayerCharacterName(_playerCharacterIndex);
        PlayerShipDescription.Text = Loader.GetPlayerShipDescription(_playerShipIndex);
        PlayerCharacterDescription.Text = Loader.GetPlayerCharacterDescription(_playerCharacterIndex);
        ScoreDescription.Text =
            "Best Score: " + HighScores.GetBestScore() + "\nLast Score: " + HighScores.GetLastScore();

        var printVisitor = new PrintVisitor(canvas);

        foreach (var customTextBlock in _customTextBlockIterator)
            printVisitor.Print(customTextBlock);

        foreach (var clickableImage in _clickableImageIterator)
            printVisitor.Print(clickableImage);

        canvas.Children.Add(_playerShips[_playerShipIndex]);
        Canvas.SetLeft(_playerShips[_playerShipIndex], 760);
        Canvas.SetTop(_playerShips[_playerShipIndex], 150);

        canvas.Children.Add(_playerCharacters[_playerCharacterIndex]);
        Canvas.SetLeft(_playerCharacters[_playerCharacterIndex], 760);
        Canvas.SetTop(_playerCharacters[_playerCharacterIndex], 400);
    }

    internal void Subscribe(ClickableImage clickableImage) => _subscribers.Add(clickableImage);
    internal void Unsubscribe(ClickableImage clickableImage) => _subscribers.Remove(clickableImage);
    private void NotifyAll(bool on, int x, int y) => _subscribers.ForEach(subscriber => subscriber.Update(on, x, y));
}