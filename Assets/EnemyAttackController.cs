using System.Collections;
using System.Collections.Generic;
using Assets.Input_Handlers;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyAttack))]
public class EnemyAttackController : MonoBehaviour
{
    private EnemyAttack _enemyAttack;
    private float _attackCooldown = 0;

    public float AttackRange = 10f;
    public float AttackDelay = .5f;

    public UnityEvent OnAttackStart;
    public UnityEvent OnAttack;

    void Awake()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
    }
    // Update is called once per frame
    void Update()
    {
        _attackCooldown -= Time.deltaTime;
        if(_attackCooldown > 0) return;
        _enemyAttack.AttackDirection =
            GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        if (AttackRange > _enemyAttack.AttackDirection.magnitude)
        {
            StartCoroutine(AttackRoutine());
        }

    }

    private IEnumerator AttackRoutine()
    {
        OnAttackStart.Invoke();
        _attackCooldown = 3f;
        yield return new WaitForSeconds(AttackDelay);
        _enemyAttack.Attack();
        OnAttack.Invoke();
        
    }
}
