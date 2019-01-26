using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameState CurrentState;

    private ImageFader _imageFader;

    public void SetState(GameState nextState)
    {
        CurrentState.DisableState();
        CurrentState = nextState;
        CurrentState.EnableState();
    }

    [NaughtyAttributes.Button("Fade to black")]
    public void FadeFore1()
    {
        if (_imageFader == null)
            _imageFader = FindObjectOfType<ImageFader>();
        _imageFader.FadeToAlpha(.3f, 1);
    }

    [NaughtyAttributes.Button("Fade to transparent")]
    public void FadeFore0()
    {
        if (_imageFader == null)
            _imageFader = FindObjectOfType<ImageFader>();
        _imageFader.FadeToAlpha(.3f, 0);
    }
}
