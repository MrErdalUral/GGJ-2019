using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject DamageObjectPrefab;

    private Vector2 _direction;
    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public void SetDirection(Vector2 dir)
    {
        Direction = dir.normalized;
    }

    public void MeleeAttack(bool attack)
    {
        if (!attack) return;
        Debug.Log("Attack Direction" + Direction);
        var dmgObj = Instantiate(DamageObjectPrefab, transform.position + (Vector3)Direction * 1.5f, Quaternion.identity);
        Destroy(dmgObj,0.5f);
    }

    
}
