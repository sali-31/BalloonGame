using UnityEngine;
using UnityEngine.InputSystem; // For Keyboard.current

public class PlayerShoot : MonoBehaviour
{
    public GameObject pinPrefab; // Prefab of the pin to shoot
    public float pinSpeed = 8f;  // Speed of the pin

    // NEW: animator for shoot recoil
    private Animator anim;

    void Start()
    {
        // Try to get Animator from the same object (Player)
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Fire when player presses Space or Ctrl
        if (keyboard.spaceKey.wasPressedThisFrame || keyboard.leftCtrlKey.wasPressedThisFrame)
        {
            ShootPin();
        }
    }

    void ShootPin()
    {
        // Spawn the pin upright (no prefab tilt)
        GameObject pin = Instantiate(pinPrefab, transform.position, Quaternion.identity);

        // Move it straight up
        var move = pin.GetComponent<PinMovement>();
        if (move != null)
        {
            move.SetDirection(Vector3.up);
            move.speed = pinSpeed;
        }

        // NEW: play shoot recoil animation
        if (anim != null)
        {
            // assumes clip name is "GokuShoot"
            anim.Play("GokuShoot", 0, 0f);
        }
    }
}
