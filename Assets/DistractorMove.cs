using UnityEngine;

public class DistractorMove : MonoBehaviour
{
    public float speed = 3f;
    public float leftX = -8f;
    public float rightX = 8f;
    int dir = 1;

    void Start()
    {
        // ---------- DIFFICULTY MULTIPLIER ----------
        float multiplier = 1f;

        if (GameSettings.difficultyIndex == 0)       // Easy
            multiplier = 0.75f;
        else if (GameSettings.difficultyIndex == 1)  // Normal
            multiplier = 1f;
        else if (GameSettings.difficultyIndex == 2)  // Hard
            multiplier = 1.5f;

        speed *= multiplier; // keep your tuned speed, just scale per difficulty
        // ------------------------------------------
    }

    void Update()
    {
        transform.Translate(Vector3.right * dir * speed * Time.deltaTime);

        if (transform.position.x > rightX)
            dir = -1;
        else if (transform.position.x < leftX)
            dir = 1;
    }
}
