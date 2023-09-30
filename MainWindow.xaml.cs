using System;
using System.Windows.Threading;
using SpaceInvaders.Game.Core;

namespace SpaceInvaders;

public partial class MainWindow
{
    private readonly DispatcherTimer _timer = new(DispatcherPriority.Render);
    private readonly Engine _engine = new();

    public MainWindow()
    {
        InitializeComponent();
        _timer.Tick += Tick;
        _timer.Interval = TimeSpan.FromMilliseconds(16);
        _timer.Start();
    }

    private void Tick(object? sender, EventArgs e)
    {
        _engine.Tick();
        _engine.Update();
        _engine.Print(GameCanvas);
    }
}