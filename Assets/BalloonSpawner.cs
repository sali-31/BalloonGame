using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;   // assign the Balloon prefab here
    public Transform[] spawnPoints;    // positions in the sky

    void Start()
    {
        int balloonCount = 1;   // default: Easy

        if (GameSettings.difficultyIndex == 0)        // Easy
        {
            balloonCount = 1;   // 1 balloon
        }
        else if (GameSettings.difficultyIndex == 1)   // Normal
        {
            balloonCount = 3;   // 3 balloons
        }
        else if (GameSettings.difficultyIndex == 2)   // Hard
        {
            balloonCount = 5;   // 5 balloons
        }

        for (int i = 0; i < balloonCount && i < spawnPoints.Length; i++)
        {
            Instantiate(balloonPrefab, spawnPoints[i].position, Quaternion.identity);
        }
    }
}
