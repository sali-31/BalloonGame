using UnityEngine;
using UnityEngine.InputSystem; // Keyboard.current

public class PlayerShoot : MonoBehaviour
{
    [Header("Pin")]
    public GameObject pinPrefab;  
    public float pinSpeed = 8f;

    [Header("Recoil (choose one method)")]
    public FireRecoil recoil;     
    private Animator anim;        // Uses your Animator Controller (_PlayerAnim)

    private const string SHOOT_TRIGGER = "Shoot";   

    void Start()
    {
        
        anim = GetComponent<Animator>();

        if (recoil == null)
            recoil = GetComponent<FireRecoil>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Fire when Space or Left Ctrl is pressed
        if (keyboard.spaceKey.wasPressedThisFrame || keyboard.leftCtrlKey.wasPressedThisFrame)
        {
            ShootPin();
        }
    }

    void ShootPin()
    {
        // 1) Spawn the pin
        GameObject pin = Instantiate(pinPrefab, transform.position, Quaternion.identity);

        // 2) Move it straight up
        var move = pin.GetComponent<PinMovement>();
        if (move != null)
        {
            move.SetDirection(Vector3.up);
            move.speed = pinSpeed;
        }

        // 3) Play recoil (Animator first; fallback to FireRecoil script)
        PlayRecoil();
    }

    void PlayRecoil()
    {
        // Method A (Animator): uses Trigger "Shoot"
        if (anim != null)
        {
            anim.ResetTrigger(SHOOT_TRIGGER);  // helps if you spam-shoot
            anim.SetTrigger(SHOOT_TRIGGER);   
            return;
        }

        if (recoil != null)
        {
            recoil.Play();
            return;
        }

        Debug.LogWarning("PlayerShoot: No Animator and no FireRecoil found/assigned.");
    }
}
