using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BossController : MonoBehaviour
{
    private Animator _animator;
    private float _attackCooldown;
    public float AttackCooldownTime = 10f;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _attackCooldown = AttackCooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        _attackCooldown -= Time.deltaTime;
        if (_attackCooldown < 0)
            Attack();

    }

    private void Attack()
    {
        var attackType = Random.Range(0, 4);
        switch (attackType)
        {
            case 0:
                _animator.SetTrigger("Attack1");
                break;
            case 1:
                _animator.SetTrigger("Attack2");
                break;
            case 2:
                _animator.SetTrigger("Attack1Left");
                break;
            case 3:
                _animator.SetTrigger("Attack2Right");
                break;
            default:
                break;
        }
        _attackCooldown = AttackCooldownTime;
    }
}
