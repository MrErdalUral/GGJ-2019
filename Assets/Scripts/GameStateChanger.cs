using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    public GameState NextState;

    [NaughtyAttributes.Button("Change State")]
    public void SetNextState() => GameManager.Instance.SetState(NextState);
}
