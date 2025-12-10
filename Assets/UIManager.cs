using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject settingsPanel;
    public GameObject highScoresPanel;

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenHighScores()
    {
        highScoresPanel.SetActive(true);
    }

    public void CloseHighScores()
    {
        highScoresPanel.SetActive(false);
    }
}
