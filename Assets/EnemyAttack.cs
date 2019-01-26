using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAttack : MonoBehaviour
{
    private Rigidbody2D _body;

    public EnemyAttackType AttackType = EnemyAttackType.Melee;
    public GameObject AttackObjectPrefab;

    public Vector2 AttackDirection;
    public float AttackMovementSpeed = 10f;
    public float ProjectileSpeed = 100f;

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   public  void Attack()
    {
        if (AttackType == EnemyAttackType.Melee)
        {
            var atkObj = Instantiate(AttackObjectPrefab, transform.position + (Vector3)AttackDirection.normalized,
                Quaternion.identity);
            atkObj.transform.parent = transform;
            _body.velocity = AttackDirection.normalized * AttackMovementSpeed;
            Destroy(atkObj, 0.25f);

        }
        else if (AttackType == EnemyAttackType.Ranged)
        {
            var atkObj = Instantiate(AttackObjectPrefab, transform.position + (Vector3)AttackDirection.normalized,
                Quaternion.identity);
            atkObj.AddComponent<ObjectScaler>();
            atkObj.GetComponent<Rigidbody2D>().velocity = AttackDirection.normalized * ProjectileSpeed;
            Destroy(atkObj, 10f);

        }
    }
}

public enum EnemyAttackType
{
    Melee,Ranged
}