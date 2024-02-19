using UnityEngine;

public class HealthDamagablePart : MonoBehaviour, IDamagable
{
    [SerializeField] private Health _health;

    public void Damage(float damage)
    {
        _health.Damage(damage);
    }
}