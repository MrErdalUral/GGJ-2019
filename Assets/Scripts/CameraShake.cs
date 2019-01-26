using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void Shake(float magnitude, float duration, Vector2 direction)
    {
        StartCoroutine(ShakeCoroutine(magnitude, duration, direction));
    }

    private IEnumerator ShakeCoroutine(float magnitude, float duration, Vector2 direction)
    {
        Camera.main.transform.Translate(direction * magnitude);
        yield return new WaitForSeconds(duration);
        Camera.main.transform.Translate(-direction * magnitude);
    }
}
