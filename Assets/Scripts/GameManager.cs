using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float TimeScale;

    [SerializeField] private GameStates _currentState;

    public GameStates CurrentState
    {
        get { return _currentState; }
        private set
        {
            _currentState = value;

            switch (value)
            {
                case GameStates.None:
                    break;
                case GameStates.Menu:
                    OnMenu();
                    break;
                case GameStates.Play:
                    OnPlay();
                    break;
                case GameStates.Pause:
                    OnPause();
                    break;
                case GameStates.DreamStart:
                    OnDreamStart();
                    break;
                case GameStates.DreamEnd:
                    OnDreamEnd();
                    break;
                case GameStates.Epilogue:
                    OnEpilogue();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }
    }

    public static GameManager Instance { get; private set; }

    public delegate void GameStateChange();

    public event GameStateChange OnMenu = () => { };
    public event GameStateChange OnDreamStart = () => { };
    public event GameStateChange OnPlay = () => { };
    public event GameStateChange OnDreamEnd = () => { };
    public event GameStateChange OnPause = () => { };
    public event GameStateChange OnEpilogue = () => { };

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Time.timeScale = 0;
        OnDreamStart += () =>
        {
            Time.timeScale = 0;
            var cor = CommonCoroutines.DelayedActionRealtime(2, () => Instance.SetState(GameStates.Play));
            Instance.StartCoroutine(cor);
        };
        OnPlay += () =>
        {
            Time.timeScale = Instance.TimeScale;
        };

        var coroutine = CommonCoroutines.DelayedActionRealtime(2, () => Instance.SetState(GameStates.DreamStart));
        StartCoroutine(coroutine);
    }

    public void SetState(GameStates nextState)
    {
        CurrentState = nextState;
    }
}
