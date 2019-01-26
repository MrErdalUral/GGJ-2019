using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameState", menuName = "GameState")]
public class GameState : ScriptableObject
{
    public float Delay;

    [SerializeField] private UnityEvent OnEnabled;
    [SerializeField] private UnityEvent OnDisabled;
    [SerializeField] private UnityEvent OnDelayedAction;
    private Action _action;

    public void EnableState()
    {
        if (_action == null)
            _action = () => OnDelayedAction.Invoke();

        OnEnabled.Invoke();
        GameManager.Instance.StartCoroutine(CommonCoroutines.DelayedAction(Delay, _action));
    }

    public void DisableState() => OnDisabled.Invoke();
}
