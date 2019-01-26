using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAttack : MonoBehaviour
{
    private Rigidbody2D _body;

    public EnemyAttackType AttackType = EnemyAttackType.Melee;

    public Vector2 AttackDirection;
    public float AttackMovementSpeed = 10f;

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   public  void Attack()
    {
        if (AttackType == EnemyAttackType.Melee)
        {
            _body.velocity = AttackDirection.normalized * AttackMovementSpeed;
        }
    }
}

public enum EnemyAttackType
{
    Melee,Ranged
}