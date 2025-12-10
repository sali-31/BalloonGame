using UnityEngine;
using UnityEngine.UI;

public class HighScoresUI : MonoBehaviour
{
    public Text[] scoreTexts;

    void OnEnable()
    {
        HighScoreManager.LoadScores();

        for (int i = 0; i < HighScoreManager.MaxScores; i++)
        {
            int score = HighScoreManager.scores[i];
            scoreTexts[i].text = (i + 1) + ". " + score;
        }
    }
}
