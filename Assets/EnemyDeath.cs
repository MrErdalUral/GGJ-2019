using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public void Death()
    {
        Destroy(gameObject,0.5f);
    }
}
