using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;

    public float PercentFromMax => Current / _max;

    public float Max => _max;

    public float Current
    {
        get => _current;

        set
        {
            _current = Mathf.Clamp(value, 0, _max);
            HealthChanged?.Invoke(_current);
        }
    }

    public event UnityAction<float> HealthChanged;

    private float _current;

    private void Start()
    {
        Current = _max;
    }

    public void Damage(float damage)
    {
        Current -= damage;
    }

    public void Heal(float heal)
    {
        Current += heal;
    }

    public void Kill()
    {
        Current = 0;
    }
}