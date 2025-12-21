using UnityEngine;

public class GameSettingsBootstrap : MonoBehaviour
{
    void Awake()
    {
        GameSettings.Load(); //makes sure volume/difficulty load before anything plays
    }
}
