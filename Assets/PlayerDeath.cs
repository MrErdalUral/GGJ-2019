using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public void Death()
    {
        Destroy(gameObject, 0.5f);
    }
}