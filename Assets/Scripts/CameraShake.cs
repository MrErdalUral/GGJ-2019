using System.Collections;
using UnityEngine;

public static class CameraShake
{
    private static bool _lock;

    public static void Shake(MonoBehaviour behavior, float magnitude, float duration, Vector2 direction)
    {
        behavior.StartCoroutine(ShakeCoroutine(magnitude, duration, direction));
    }

    private static IEnumerator ShakeCoroutine(float magnitude, float duration, Vector2 direction)
    {
        if (_lock) yield break;
        _lock = true;

        Camera.main.transform.Translate(direction * magnitude);
        yield return new WaitForSeconds(duration);
        Camera.main.transform.Translate(-direction * magnitude);

        _lock = false;
    }
}
