using UnityEngine;

public static class GameSettings
{
    public static int difficultyIndex = 1;
    public static float volume = 1f;

    private static bool loaded = false;

    // ✅ Call this at game start (MainMenu) before music plays
    public static void Load()
    {
        if (loaded) return;

        difficultyIndex = PlayerPrefs.GetInt("DifficultyIndex", 1);
        volume = PlayerPrefs.GetFloat("MasterVolume", 1f);

        // clamp just in case prefs gets corrupted
        volume = Mathf.Clamp01(volume);

        AudioListener.pause = false;
        AudioListener.volume = volume;

        loaded = true;
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("DifficultyIndex", difficultyIndex);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    // Optional helper so other scripts can safely apply volume
    public static void ApplyVolume()
    {
        AudioListener.pause = false;
        AudioListener.volume = Mathf.Clamp01(volume);
    }
}
