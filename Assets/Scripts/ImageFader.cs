using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    public Image CanvasFader;
    private IEnumerator _currentCoroutine;

    public void FadeToAlpha(float duration, float targetAlpha)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = FadeCoroutine(duration, targetAlpha);
        StartCoroutine(_currentCoroutine);
    }

    public void SetImageSprite(Sprite sprite) => CanvasFader.sprite = sprite;

    public void ResetImageSprite() => CanvasFader.sprite = null;

    private IEnumerator FadeCoroutine(float duration, float targetAlpha)
    {
        while (!CanvasFader.color.a.Approx(targetAlpha))
        {
            var deltaAlpha = Time.unscaledDeltaTime * (targetAlpha - CanvasFader.color.a) / duration;
            CanvasFader.color = CanvasFader.color.AddAlpha(deltaAlpha);
            yield return null;
        }
    }
}
