using System.Collections;
using UnityEngine;

public class FireRecoil : MonoBehaviour
{
    [Header("Recoil Shape")]
    public float squashX = 0.88f;     // < 1 squashes X
    public float squashY = 1.12f;     // > 1 stretches Y
    public float bobUp = 0.08f;       // local Y offset (units)

    [Header("Timing")]
    public float inTime = 0.06f;      // fast snap
    public float outTime = 0.10f;     // return time

    Coroutine _co;
    Vector3 _baseScale;
    Vector3 _baseLocalPos;

    void Awake()
    {
        _baseScale = transform.localScale;
        _baseLocalPos = transform.localPosition;
    }

    public void Play()
    {
        if (_co != null) StopCoroutine(_co);
        _co = StartCoroutine(Recoil());
    }

    IEnumerator Recoil()
    {
        Vector3 targetScale = new Vector3(_baseScale.x * squashX, _baseScale.y * squashY, _baseScale.z);
        Vector3 targetPos = _baseLocalPos + new Vector3(0f, bobUp, 0f);

        // Phase 1: snap in
        float t = 0f;
        while (t < inTime)
        {
            t += Time.deltaTime;
            float a = Mathf.Clamp01(t / inTime);
            // ease out (snappy)
            float e = 1f - Mathf.Pow(1f - a, 3f);

            transform.localScale = Vector3.LerpUnclamped(_baseScale, targetScale, e);
            transform.localPosition = Vector3.LerpUnclamped(_baseLocalPos, targetPos, e);
            yield return null;
        }

        // Phase 2: return
        t = 0f;
        while (t < outTime)
        {
            t += Time.deltaTime;
            float a = Mathf.Clamp01(t / outTime);
            // ease in-out
            float e = a * a * (3f - 2f * a);

            transform.localScale = Vector3.LerpUnclamped(targetScale, _baseScale, e);
            transform.localPosition = Vector3.LerpUnclamped(targetPos, _baseLocalPos, e);
            yield return null;
        }

        transform.localScale = _baseScale;
        transform.localPosition = _baseLocalPos;
        _co = null;
    }
}
