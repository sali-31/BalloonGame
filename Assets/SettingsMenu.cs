using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Slider volumeSlider;              // CHECK: drag VolumeSlider here
    [SerializeField] private TMP_Dropdown difficultyDropdown;  // CHECK: drag DifficultyDropdown here

    void Start()
    {
        // Load saved settings
        GameSettings.Load();

        // --- Volume ---
        if (volumeSlider != null)
            volumeSlider.SetValueWithoutNotify(GameSettings.volume); // CHECK: slider range should be 0..1

        AudioListener.pause = false;
        AudioListener.volume = GameSettings.volume;

        // --- Difficulty ---
        if (difficultyDropdown != null)
            difficultyDropdown.SetValueWithoutNotify(GameSettings.difficultyIndex); // CHECK: 0 Easy, 1 Normal, 2 Hard
    }

    // Called by VolumeSlider -> On Value Changed (float)
    public void SetVolume(float value)
    {
        GameSettings.volume = value;

        AudioListener.pause = false;
        AudioListener.volume = value;

        GameSettings.Save();

        // Optional debug
        Debug.Log("Volume set to: " + value);
    }

    // Called by DifficultyDropdown -> On Value Changed (int)
    public void SetDifficulty(int index)
    {
        GameSettings.difficultyIndex = index;
        GameSettings.Save();

        // Optional debug
        Debug.Log("Difficulty set to index: " + index);
    }
}
