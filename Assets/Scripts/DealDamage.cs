using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int DamageAmount;

    public LayerMask DamageLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherLayer = 1 << other.gameObject.layer;
        if ((otherLayer & DamageLayer) == otherLayer)
        {
            other.gameObject.GetComponent<Health>().DealDamage(DamageAmount);
            var otherBody = other.GetComponent<Rigidbody2D>();
            var body = GetComponent<Rigidbody2D>();
            if (otherBody && body)
            {
                Debug.Log("knockback: " + body.velocity);
                otherBody.velocity = body.velocity *  2.5f;
            }
        }
    }
}
