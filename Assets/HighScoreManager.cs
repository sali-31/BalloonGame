using UnityEngine;

public static class HighScoreManager
{
    public const int MaxScores = 5;
    public static int[] scores = new int[MaxScores];

    private static bool loaded = false;

    public static void LoadScores()
    {
        if (loaded) return;

        for (int i = 0; i < MaxScores; i++)
        {
            scores[i] = PlayerPrefs.GetInt("HighScore_" + i, 0);
        }

        loaded = true;
    }

    public static void SaveScores()
    {
        for (int i = 0; i < MaxScores; i++)
        {
            PlayerPrefs.SetInt("HighScore_" + i, scores[i]);
        }
        PlayerPrefs.Save();
    }

    public static void AddScore(int newScore)
    {
        LoadScores();

        // Insert newScore into the sorted array (highest first)
        for (int i = 0; i < MaxScores; i++)
        {
            if (newScore > scores[i])
            {
                // Shift scores down
                for (int j = MaxScores - 1; j > i; j--)
                {
                    scores[j] = scores[j - 1];
                }

                scores[i] = newScore;
                break;
            }
        }

        SaveScores();
    }
}
