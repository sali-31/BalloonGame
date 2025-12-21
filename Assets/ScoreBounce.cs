using System.Collections;
using UnityEngine;

public class ScoreBounce : MonoBehaviour
{
    public float upScale = 1.15f;
    public float upTime = 0.07f;
    public float downTime = 0.10f;
    public bool useUnscaledTime = true; // keeps working even if timescale changes

    Coroutine _co;
    RectTransform _rt;
    Vector3 _baseScale;

    void Awake()
    {
        _rt = GetComponent<RectTransform>();
        _baseScale = _rt.localScale;
    }

    public void Play()
    {
        if (_co != null) StopCoroutine(_co);
        _co = StartCoroutine(Bounce());
    }

    IEnumerator Bounce()
    {
        Vector3 target = _baseScale * upScale;

        // up
        float t = 0f;
        while (t < upTime)
        {
            t += useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            float a = Mathf.Clamp01(t / upTime);
            float e = 1f - Mathf.Pow(1f - a, 3f); // snappy
            _rt.localScale = Vector3.LerpUnclamped(_baseScale, target, e);
            yield return null;
        }

        // down
        t = 0f;
        while (t < downTime)
        {
            t += useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            float a = Mathf.Clamp01(t / downTime);
            float e = a * a * (3f - 2f * a);
            _rt.localScale = Vector3.LerpUnclamped(target, _baseScale, e);
            yield return null;
        }

        _rt.localScale = _baseScale;
        _co = null;
    }
}
