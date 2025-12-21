using UnityEngine;

public class ScoreBounceUI : MonoBehaviour
{
    private Animator anim;
    private const string TRIGGER = "Bounce"; 

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayBounce()
    {
        if (anim == null) return;
        anim.ResetTrigger(TRIGGER);
        anim.SetTrigger(TRIGGER);
    }
}
