using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyAttack))]
public class EnemyAttackController : MonoBehaviour
{
    private EnemyAttack _enemyAttack;

    public float AttackRange = 10f;
    public float AttackDelay = 1f;

    public UnityEvent OnAttackStart;
    public UnityEvent OnAttack;

    void Awake()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
    }
    // Update is called once per frame
    void Update()
    {
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
        yield return new WaitForSeconds(AttackDelay);
        OnAttack.Invoke();
        _enemyAttack.Attack();
    }
}
