using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameState", menuName = "GameState")]
public class GameState : ScriptableObject
{
    [SerializeField] private UnityEvent OnEnabled;
    [SerializeField] public UnityEvent OnDisabled;

    public void EnableState() => OnEnabled.Invoke();
    public void DisableState() => OnDisabled.Invoke();
}
