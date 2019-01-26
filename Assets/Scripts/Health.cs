using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int CurrentHp;

    public UnityEvent OnDeath;

    public void DealDamage(int amount)
    {
        CurrentHp -= amount;
        if (CurrentHp < 0)
        {
            OnDeath.Invoke();
        }
    }
}
