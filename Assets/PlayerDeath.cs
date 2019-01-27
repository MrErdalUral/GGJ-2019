using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public void Death()
    {
        SceneHelper.LoadStatic("EndLose");
    }
}
