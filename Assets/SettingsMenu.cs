using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    // called by the volume slider
    public void SetVolume(float value)
    {
        GameSettings.volume = value;
        AudioListener.volume = value;
        GameSettings.Save();
    }

    // called by the difficulty dropdown
    public void SetDifficulty(int index)
    {
        GameSettings.difficultyIndex = index;
        GameSettings.Save();
        Debug.Log("Difficulty set to index: " + index);
    }
}
