using UnityEngine;

public class AudioStateDebug : MonoBehaviour
{
    void Start()
    {
        Debug.Log("AudioListener.volume = " + AudioListener.volume);
        Debug.Log("AudioListener.pause = " + AudioListener.pause);
    }
}
