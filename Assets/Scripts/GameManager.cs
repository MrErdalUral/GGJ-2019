using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState _currentState;
    public GameState CurrentState
    {
        get { return _currentState;}
        private set { _currentState = value; }
    }

    private GameState _initialState;

    private ImageFader _imageFader;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _initialState = CurrentState;
        CurrentState.EnableState();
    }

    private void OnApplicationQuit() => CurrentState = _initialState;

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
