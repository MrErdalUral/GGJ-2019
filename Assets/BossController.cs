using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BossController : MonoBehaviour
{
    private Animator _animator;
    private float _attackCooldown;
    public float AttackCooldownTime = 10f;
    public int BossHealth = 20;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        ResetAttackCooldown();
    }

    private void ResetAttackCooldown()
    {
        AttackCooldownTime = Mathf.Lerp(1, 10f, (float)BossHealth / 20);
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
        var player = GameObject.FindGameObjectWithTag("Player");
        if (!player) return;

        var attackType = Random.Range(0, 4);
        if (player.transform.position.x > 0)
        {
            attackType = Random.Range(2, 4);
        }
        else
        {
            attackType = Random.Range(0, 2);
        }
        switch (attackType)
        {
            case 0:
                _animator.SetTrigger("Attack1");
                break;
            case 1:
                _animator.SetTrigger("Attack1Left");
                break;
            case 2:
                _animator.SetTrigger("Attack2");
                break;
            case 3:
                _animator.SetTrigger("Attack2Right");
                break;
            default:
                break;
        }
        ResetAttackCooldown();
    }

    private void AttackImpact()
    {
        CameraShake.Shake(this, 1, .05f, Vector2.down);
        GetComponent<PlaySound>().Play();
    }

    private void HandSlide(AudioClip clip)
    {
        GetComponent<PlaySound>().Play(clip);
    }
}
