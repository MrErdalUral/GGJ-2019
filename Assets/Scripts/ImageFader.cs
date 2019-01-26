using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    public Image CanvasImage;
    private IEnumerator _currentCoroutine;

    public void FadeToAlpha(float duration, float targetAlpha)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = FadeCoroutine(duration, targetAlpha);
        StartCoroutine(_currentCoroutine);
    }

    public void SetAlpha1() => CanvasImage.color = CanvasImage.color.WithAlpha(1);
    public void SetAlpha0() => CanvasImage.color = CanvasImage.color.WithAlpha(0);

    private IEnumerator FadeCoroutine(float duration, float targetAlpha)
    {
        while (!CanvasImage.color.a.Approx(targetAlpha))
        {
            var deltaAlpha = Time.unscaledDeltaTime * (targetAlpha - CanvasImage.color.a) / duration;
            CanvasImage.color = CanvasImage.color.AddAlpha(deltaAlpha);
            yield return null;
        }
    }

    private void OnEnable()
    {
        CanvasImage = GetComponent<Image>();
    }

    [NaughtyAttributes.Button("Fade to black")]
    public void FadeFore1() => FadeToAlpha(.3f, 1);

    [NaughtyAttributes.Button("Fade to transparent")]
    public void FadeFore0() => FadeToAlpha(.3f, 0);
}
