using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossDealDamage : MonoBehaviour
{
    public int DamageAmount;
    public float ShakeMultiplier;
    public bool DestroyOnHit;
    public UnityEvent OnDestroy;

    public LayerMask DamageLayer;

    private HashSet<Rigidbody2D> _damageHistory;

    private void Start() => _damageHistory = new HashSet<Rigidbody2D>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherLayer = 1 << other.gameObject.layer;
        if ((otherLayer & DamageLayer) != otherLayer) return;

        other.gameObject.GetComponent<Health>().DealDamage(DamageAmount);
        var otherBody = other.GetComponent<Rigidbody2D>();
        if (!otherBody) return;

        //_damageHistory.Add(otherBody);

        otherBody.velocity = otherBody.transform.position - transform.position;

        //print($"{name} hits {otherBody.name}. velocity={otherBody.velocity}");

        CameraShake.Shake(this, 1, .05f, otherBody.velocity.normalized);
        if (DestroyOnHit)
            Destroy();
    }

    private void Destroy()
    {
        OnDestroy.Invoke();
        Destroy(gameObject);
    }
}
