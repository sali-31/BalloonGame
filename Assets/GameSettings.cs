using UnityEngine;
//testchange
public static class GameSettings
{
    // 0 = Easy, 1 = Normal, 2 = Hard
    public static int difficultyIndex = 1;

    // Master volume (0–1)
    public static float volume = 1f;

    private static bool loaded = false;

    public static void Load()
    {
        if (loaded) return;

        difficultyIndex = PlayerPrefs.GetInt("DifficultyIndex", 1);
        volume = PlayerPrefs.GetFloat("MasterVolume", 1f);

        AudioListener.volume = volume;

        loaded = true;
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("DifficultyIndex", difficultyIndex);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }
}
