using System;

namespace SpaceInvaders.Game.Utils;

public static class HighScores
{
    private static int _lastScore, _bestScore;

    public static void SetLastScore(int score)
    {
        _lastScore = score;
        _bestScore = Math.Max(_bestScore, score);
    }

    public static int GetLastScore() => _lastScore;
    public static int GetBestScore() => _bestScore;
}