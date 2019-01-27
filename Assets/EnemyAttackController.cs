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

    public Animator Animator;
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
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        if(!playerObject) return;
        _enemyAttack.AttackDirection =
            playerObject.transform.position - transform.position;
        transform.localScale = new Vector3(-Mathf.Sign(_enemyAttack.AttackDirection.x), 1, 1);
        if (AttackRange > _enemyAttack.AttackDirection.magnitude)
        {
            StartCoroutine(AttackRoutine());
        }

    }

    private IEnumerator AttackRoutine()
    {
        Animator.SetTrigger("AttackStart");
        OnAttackStart.Invoke();
        _attackCooldown = 3f;
        yield return new WaitForSeconds(AttackDelay);
        Animator.SetTrigger("Attack");
        _enemyAttack.Attack();
        OnAttack.Invoke();
        
    }
}
