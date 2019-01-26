using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int DamageAmount;
    public float ShakeMultiplier;

    public LayerMask DamageLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherLayer = 1 << other.gameObject.layer;
        if ((otherLayer & DamageLayer) != otherLayer) return;

        other.gameObject.GetComponent<Health>().DealDamage(DamageAmount);
        var otherBody = other.GetComponent<Rigidbody2D>();
        var body = GetComponent<Rigidbody2D>();
        if (!otherBody || !body) return;

        Debug.Log("knockback: " + body.velocity);
        otherBody.velocity = body.velocity *  2.5f;

        Camera.main.GetComponent<CameraShake>()
            .Shake(DamageAmount * ShakeMultiplier, .1f, body.velocity.normalized);
    }
}
