using UnityEngine;

public class CharacterHealthDamageOnHunger : MonoBehaviour
{
    [SerializeField] private float _damagePerSecond;
    [SerializeField] private Character _character;

    private bool _active = false;

    private void Start()
    {
        _character.Hunger.StateUpdated += CheckHungerState;
    }

    private void CheckHungerState(HungerState state)
    {
        if(state == HungerState.Exhausted)
        {
            _active = true;
            return;
        }

        _active = false;
    }

    private void Update()
    {
        if (_active == false) return;

        _character.Health.Current -= Time.deltaTime * _damagePerSecond;
    }
}