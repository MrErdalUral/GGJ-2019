using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int CurrentHp;

    public UnityEvent OnDeath;
    public UnityEvent OnHit;

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
}
