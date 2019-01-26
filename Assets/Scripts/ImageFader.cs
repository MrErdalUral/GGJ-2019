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

    public void SetVisible() => CanvasFader.color = CanvasFader.color.WithAlpha(1);
    public void SetInvisible() => CanvasFader.color = CanvasFader.color.WithAlpha(0);

    public void SetImageSprite(Sprite sprite)
    {
        print($"Set sprite to {sprite.name}");
        CanvasFader = Instantiate(CanvasFader);
        CanvasFader.sprite = sprite;
    }

    public void ResetImageSprite()
    {
        print($"Reset sprite");
        CanvasFader.sprite = null;
    }

    private IEnumerator FadeCoroutine(float duration, float targetAlpha)
    {
        while (!CanvasFader.color.a.Approx(targetAlpha))
        {
            var deltaAlpha = Time.unscaledDeltaTime * (targetAlpha - CanvasFader.color.a) / duration;
            CanvasFader.color = CanvasFader.color.AddAlpha(deltaAlpha);
            yield return null;
        }
    }

    [NaughtyAttributes.Button("Fade to black")]
    public void FadeFore1() => FadeToAlpha(.3f, 1);

    [NaughtyAttributes.Button("Fade to transparent")]
    public void FadeFore0() => FadeToAlpha(.3f, 0);
}
