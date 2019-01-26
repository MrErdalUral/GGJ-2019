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
        }
    }
}
