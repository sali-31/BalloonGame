using UnityEngine;

public class MusicManager : MonoBehaviour
{
private static MusicManager instance;

void Awake()
{
// If one already exists, delete this duplicate
if (instance != null && instance != this)
{
Destroy(gameObject);
return;
}

instance = this;
DontDestroyOnLoad(gameObject);
}
}