using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // NEW: animator for the score text bounce
    public Animator scoreTextAnimator;

    private int score;
    private bool isLoadingNext = false;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(float balloonSize)
    {
        // Smaller balloon → higher score
        int points = Mathf.RoundToInt(100f / balloonSize);
        score += points;
        UpdateScoreText();
    }

    public void RestartLevel()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    // OLD name kept so other scripts won't break
    public void LoadNextLevel()
    {
        LoadNextLevelWithDelay(0f);
    }

    // NEW: lets PopOnContact say "wait 0.6s"
    public void LoadNextLevelWithDelay(float delay)
    {
        if (isLoadingNext) return;
        isLoadingNext = true;

        if (delay <= 0f)
        {
            DoLoadNextLevel();
        }
        else
        {
            Invoke(nameof(DoLoadNextLevel), delay);
        }
    }

    private void DoLoadNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Middle of the game: just go to the next level like before
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            // We finished the last level: record this run in the high scores
            HighScoreManager.AddScore(score);

            // Go back to the main menu scene (make sure it's in Build Settings)
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        // NEW: play bounce animation whenever the score text updates
        if (scoreTextAnimator != null)
        {
            // assumes the clip is called "ScoreBounce"
            scoreTextAnimator.Play("ScoreBounce", 0, 0f);
        }
    }
}
