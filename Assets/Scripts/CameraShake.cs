using System.Collections;
using UnityEngine;

public static class CameraShake
{
    public static void Shake(MonoBehaviour behavior, float magnitude, float duration, Vector2 direction)
    {
        behavior.StartCoroutine(ShakeCoroutine(magnitude, duration, direction));
    }

    private static IEnumerator ShakeCoroutine(float magnitude, float duration, Vector2 direction)
    {
        Camera.main.transform.Translate(direction * magnitude);
        yield return new WaitForSeconds(duration);
        Camera.main.transform.Translate(-direction * magnitude);
    }
}
