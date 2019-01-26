using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameState", menuName = "GameState")]
public class GameState : ScriptableObject
{
    public UnityEvent OnEnabled;
    public UnityEvent OnDisabled;

    private void OnEnable() => OnEnabled.Invoke();
    private void OnDisable() => OnDisabled.Invoke();
}
