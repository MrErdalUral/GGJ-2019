using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameState", menuName = "GameState")]
public class GameState : ScriptableObject
{
    public float Delay;

    [SerializeField] private UnityEvent _onEnabled;
    [SerializeField] private UnityEvent _onDisabled;
    [SerializeField] private UnityEvent _onDelayedAction;
    private Action _action;

    public void EnableState()
    {
        if (_action == null)
            _action = () => _onDelayedAction?.Invoke();

        _onEnabled?.Invoke();
        GameManager.Instance.StartCoroutine(CommonCoroutines.DelayedAction(Delay, _action));
    }

    public void DisableState() => _onDisabled?.Invoke();
}
