using UnityEngine;

public class PopOnContact : MonoBehaviour
{
    public AudioClip popSound;

    private GameManager gameManager;

    public float pinDestroyDelay = 0.55f;
    public float nextLevelDelay = 0.6f;

    void Awake()
    {
        // Try once at spawn
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    // ✅ helper: re-find if missing
    GameManager GM()
    {
        if (gameManager == null)
            gameManager = Object.FindFirstObjectByType<GameManager>();
        return gameManager;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // This script is on the PIN
        if (!CompareTag("pin"))
            return;

        if (other.CompareTag("Balloon"))
        {
            float balloonSize = other.transform.localScale.x;

            if (popSound != null)
            {
                Camera cam = Camera.main;
                Vector3 pos = cam != null ? cam.transform.position : transform.position;
                AudioSource.PlayClipAtPoint(popSound, pos);
            }

            Destroy(other.gameObject);

            var gm = GM();
            if (gm != null)
            {
                gm.AddScore(balloonSize);
                gm.LoadNextLevelWithDelay(nextLevelDelay);
            }
            else
            {
                Debug.LogWarning("PopOnContact: GameManager not found!");
            }

            Destroy(gameObject, pinDestroyDelay);
        }
        else if (other.CompareTag("Distractor"))
        {
            var gm = GM();
            if (gm != null)
                gm.RestartLevel();

            Destroy(gameObject, 0.25f);
        }
    }
}
