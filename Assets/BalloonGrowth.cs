using UnityEngine;

public class BalloonGrowth : MonoBehaviour
{
    public float growRate = 0.005f;   
    public float maxSize = 2.5f;

    private GameManager gameManager;

    // NEW: animator + warning flag
    private Animator anim;
    private bool warningPlayed = false;

    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();

        // NEW: get Animator on this balloon (for warning + pop)
        anim = GetComponent<Animator>();

        // ---------- DIFFICULTY MULTIPLIER ----------
        float multiplier = 1f;

        if (GameSettings.difficultyIndex == 0)       // Easy
            multiplier = 0.75f;
        else if (GameSettings.difficultyIndex == 1)  // Normal
            multiplier = 1f;
        else if (GameSettings.difficultyIndex == 2)  // Hard
            multiplier = 1.5f;

        growRate *= multiplier; // your base growRate, scaled by difficulty
        // ------------------------------------------

        InvokeRepeating(nameof(Grow), 1f, 4f);   // grow every 4 seconds
    }

    void Grow()
    {
        transform.localScale += Vector3.one * growRate;

        // NEW: play warning animation once when balloon is big enough
        if (!warningPlayed && transform.localScale.x >= maxSize * 0.8f)
        {
            warningPlayed = true;

            if (anim != null)
            {
                // This assumes you named the clip "BalloonWarning"
                anim.Play("BalloonWarning", 0, 0f);
            }
        }

        if (transform.localScale.x >= maxSize)
        {
            CancelInvoke(nameof(Grow));
            if (gameManager != null)
                gameManager.RestartLevel();   // balloon got too big → restart current level
            Destroy(gameObject);
        }
    }

    public void Pop()
    {
        CancelInvoke(nameof(Grow));

        // NEW: play pop animation when balloon is popped
        if (anim != null)
        {
            // This assumes the pop clip is called "BalloonPop"
            anim.Play("BalloonPop", 0, 0f);
        }

        if (gameManager != null)
        {
            gameManager.AddScore(transform.localScale.x);
            gameManager.LoadNextLevel();   // ← keep your existing Lab 4 behavior
        }

        Destroy(gameObject);
    }
}
