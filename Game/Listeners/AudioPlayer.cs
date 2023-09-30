using System;
using System.Windows.Media;

namespace SpaceInvaders.Game.Listeners;

public static class AudioPlayer
{
    private static readonly MediaPlayer BackgroundPlayer = new();
    private static readonly MediaPlayer SoundPlayer = new();

    public static void PlayBackgroundMusic()
    {
        //var uri = new Uri(@"pack://application:,,,/Game/Assets/Liero - Underwater Rock Consumer.mp3", UriKind.Absolute);
        var uri = new Uri(
            @"C:\Users\Pawel\Studia\Semestr 5\Programowanie C# i .NET\_\zadania\SpaceInvaders\Game\Assets\Liero - Underwater Rock Consumer.mp3");
        BackgroundPlayer.MediaEnded += RepeatBackgroundMusic;
        BackgroundPlayer.Open(uri);
        BackgroundPlayer.Play();
    }

    public static void StopBackgroundMusic()
    {
        BackgroundPlayer.MediaEnded -= RepeatBackgroundMusic;
        BackgroundPlayer.Stop();
    }

    public static void PlayShotSound()
    {
        var uri = new Uri(
            @"C:\Users\Pawel\Studia\Semestr 5\Programowanie C# i .NET\_\zadania\SpaceInvaders\Game\Assets\Shot.wav");
        SoundPlayer.Open(uri);
        SoundPlayer.Play();
    }

    public static void PlayCrashSound()
    {
        var uri = new Uri(
            @"C:\Users\Pawel\Studia\Semestr 5\Programowanie C# i .NET\_\zadania\SpaceInvaders\Game\Assets\Crash.wav");
        SoundPlayer.Open(uri);
        SoundPlayer.Play();
    }

    private static void RepeatBackgroundMusic(object sender, EventArgs e)
    {
        var player = (MediaPlayer)sender;
        player.Position = TimeSpan.Zero;
        player.Play();
    }
}