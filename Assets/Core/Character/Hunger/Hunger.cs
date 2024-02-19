using UnityEngine;
using UnityEngine.Events;

public class Hunger : MonoBehaviour
{
    [SerializeField] private float _hungerPerSecond = 0.05f;
    [SerializeField] private float _maxHunger = 100;
    [SerializeField] private float _hungryThresfold = 25;
    [SerializeField] private float _fullThresfold = 70;

    public float Current
    {
        get => _current;

        set
        {
            _current = Mathf.Clamp(value, 0, _maxHunger);
            HungerChanged?.Invoke(value);
            UpdateHungerState();
        }
    }

    public HungerState State
    {
        get => _state;

        set
        {
            if(_state != value)
            {
                _state = value;
                StateUpdated?.Invoke(_state);
                return;
            }

            _state = value;
        }
    }

    public event UnityAction<float> HungerChanged;
    public event UnityAction<HungerState> StateUpdated;

    private HungerState _state;
    private float _current;

    private void Start()
    {
        Current = _maxHunger;
    }

    private void UpdateHungerState()
    {
        if(Current >= _fullThresfold)
        {
            State = HungerState.Full;
        }
        else if(Current >= _hungryThresfold)
        {
            State = HungerState.Normal;
        }
        else if(Current > 0)
        {
            State = HungerState.Hungry;
        }
        else
        {
            State = HungerState.Exhausted;
        }
    }

    private void Update()
    {
        Current -= Time.deltaTime * _hungerPerSecond;
    }
}

public enum HungerState
{
    Full,
    Normal,
    Hungry,
    Exhausted
}