using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameState CurrentState;

    private ImageFader ImageFader;

    public void SetState(GameState nextState)
    {
        CurrentState = nextState;
    }

    [NaughtyAttributes.Button("Fade to black")]
    public void FadeFore1()
    {
        if (ImageFader == null)
            ImageFader = FindObjectOfType<ImageFader>();
        ImageFader.FadeToAlpha(.3f, 1);
    }

    [NaughtyAttributes.Button("Fade to transparent")]
    public void FadeFore0()
    {
        if (ImageFader == null)
            ImageFader = FindObjectOfType<ImageFader>();
        ImageFader.FadeToAlpha(.3f, 0);
    }
}
