using UnityEngine;

public class AudioBootstrap : MonoBehaviour
{
    void Awake()
    {
        AudioListener.pause = false;
        AudioListener.volume = GameSettings.volume; // uses your saved setting
    }
}
