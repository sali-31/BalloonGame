using UnityEngine;

public class DifficultyDistractors : MonoBehaviour
{
    public GameObject beerus;
    public GameObject superBuu;

    void Start()
    {
        GameSettings.Load();

        int d = GameSettings.difficultyIndex; // 0 easy, 1 normal, 2 hard

        // ✅ force OFF first (prevents "default active" bugs)
        if (beerus != null) beerus.SetActive(false);
        if (superBuu != null) superBuu.SetActive(false);

        // ✅ then enable based on difficulty
        if (d >= 1 && beerus != null) beerus.SetActive(true);
        if (d >= 2 && superBuu != null) superBuu.SetActive(true);

        Debug.Log("Difficulty = " + d + " BeerusActive=" + (beerus != null && beerus.activeSelf));
    }
}
