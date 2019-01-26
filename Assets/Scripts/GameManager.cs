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
}
