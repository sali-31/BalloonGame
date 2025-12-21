using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [Header("UI")]
    public TextMeshProUGUI scoreText;   // will be re-found each scene
    public Animator scoreTextAnimator;  // will be re-found each scene

    private int score;
    private bool isLoadingNext = false;

    private const string SCORE_BOUNCE_TRIGGER = "Bounce";

    void Awake()
    {
        // ✅ Keep ONE GameManager across all scenes
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        // Show starting score once
        UpdateScoreText(playBounce: false);
    }

    // ✅ runs every time a new scene loads
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isLoadingNext = false; // ✅ important so next level can load again

        // Find the score text in the new scene (tagging is optional; this is simplest)
        var go = GameObject.FindGameObjectWithTag("ScoreText");
        var tmp = go != null ? go.GetComponent<TextMeshProUGUI>() : null;

        if (tmp != null)
        {
            scoreText = tmp;
            scoreTextAnimator = tmp.GetComponent<Animator>();
        }

        UpdateScoreText(playBounce: false);
    }

    public void AddScore(float balloonSize)
    {
        if (balloonSize <= 0.01f) balloonSize = 0.01f;
        int points = Mathf.RoundToInt(100f / balloonSize);
        AddPoints(points);
    }

    private void AddPoints(int points)
    {
        if (points <= 0)
        {
            UpdateScoreText(playBounce: false);
            return;
        }

        score += points;
        UpdateScoreText(playBounce: true);
    }

    private void UpdateScoreText(bool playBounce)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (playBounce && scoreTextAnimator != null)
        {
            scoreTextAnimator.ResetTrigger(SCORE_BOUNCE_TRIGGER);
            scoreTextAnimator.SetTrigger(SCORE_BOUNCE_TRIGGER);
        }
    }

    public void RestartLevel()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    public void LoadNextLevel()
    {
        LoadNextLevelWithDelay(0f);
    }

    public void LoadNextLevelWithDelay(float delay)
    {
        if (isLoadingNext) return;
        isLoadingNext = true;

        if (delay <= 0f) DoLoadNextLevel();
        else Invoke(nameof(DoLoadNextLevel), delay);
    }

    private void DoLoadNextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            // finished all levels — save total score
            HighScoreManager.AddScore(score);

            // ✅ reset score for next run
            score = 0;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
