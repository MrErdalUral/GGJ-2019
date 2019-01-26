using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int CurrentHp;

    public UnityEvent OnDeath;
    public UnityEvent OnHit;
    public float EtherialTime;
    private float _etherialCooldown;

    public void DealDamage(int amount)
    {
        CurrentHp -= amount;
        if (CurrentHp < 0)
        {
            OnDeath.Invoke();
        }
        else
        {
            OnHit.Invoke();
        }
    }

    void Update()
    {
        _etherialCooldown -= Time.deltaTime;
    }

    public void BecomeGhost()
    {
        StartCoroutine(BecomeGhostRoutine());
    }

    private IEnumerator BecomeGhostRoutine()
    {
        var originalLayer = gameObject.layer;
        gameObject.layer = LayerMask.NameToLayer("Ghost");
        yield return new WaitForSeconds(EtherialTime);
        gameObject.layer = originalLayer;
    }
}
