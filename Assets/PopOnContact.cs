using UnityEngine;

public class PopOnContact : MonoBehaviour
{
    public AudioClip popSound;

    private GameManager gameManager;

    // how long to keep the pin alive (just in case)
    public float pinDestroyDelay = 0.55f;

    // how long we want the GameManager to wait before changing scene
    public float nextLevelDelay = 0.6f;

    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // SAFETY: this script is meant to be on the PIN only
        if (!CompareTag("pin"))
            return;

        // ============ HIT BALLOON ============
        if (other.CompareTag("Balloon"))
        {
            // read size BEFORE we destroy it
            float balloonSize = other.transform.localScale.x;

            // 1) play the sound in the scene (not on the pin)
            if (popSound != null)
            {
                Camera cam = Camera.main;
                Vector3 pos = cam != null ? cam.transform.position : transform.position;
                AudioSource.PlayClipAtPoint(popSound, pos);
            }

            // 2) destroy the balloon
            Destroy(other.gameObject);

            // 3) tell manager to add score + go to next level AFTER a delay
            if (gameManager != null)
            {
                gameManager.AddScore(balloonSize);
                gameManager.LoadNextLevelWithDelay(nextLevelDelay);
            }

            // 4) destroy the pin a little later (so it doesn’t vanish instantly)
            Destroy(gameObject, pinDestroyDelay);
        }
        // ============ HIT DISTRACTOR ============
        else if (other.CompareTag("Distractor"))
        {
            if (gameManager != null)
                gameManager.RestartLevel();

            Destroy(gameObject, 0.25f);
        }
    }
}
