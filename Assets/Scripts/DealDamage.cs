using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int DamageAmount;
    public float ShakeMultiplier;

    public LayerMask DamageLayer;

    private HashSet<Rigidbody2D> _damageHistory;

    private void Start() => _damageHistory = new HashSet<Rigidbody2D>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherLayer = 1 << other.gameObject.layer;
        if ((otherLayer & DamageLayer) != otherLayer) return;

        other.gameObject.GetComponent<Health>().DealDamage(DamageAmount);
        var otherBody = other.GetComponent<Rigidbody2D>();
        var body = GetComponent<Rigidbody2D>();
        if (!otherBody || !body
                       || _damageHistory.Contains(otherBody)) return;

        _damageHistory.Add(otherBody);

        otherBody.velocity = body.velocity * 2.5f;
        if (otherBody.velocity.Approx(Vector2.zero))
            otherBody.velocity = otherBody.transform.position - body.transform.position;

        print($"{name} hits {otherBody.name}. velocity={otherBody.velocity}");

        CameraShake.Shake(this, DamageAmount * ShakeMultiplier, .1f, otherBody.velocity.normalized);
    }
}
