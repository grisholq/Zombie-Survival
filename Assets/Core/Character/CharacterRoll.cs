using Zenject;
using UnityEngine;

public class CharacterRoll : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _duraction;
    [SerializeField] private float _speedMutliplyer;

    [Inject] private Joystick _joystick;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnRollStart();            
        }
    }

    private void OnRollStart()
    {
        _character.Animator.Roll();
        _character.Mover.StartDirectionalMovment();
        _character.Rotator.Enabled = false;
        Timer.Begin(_duraction).Finished += OnRollEnd;
    }

    private void OnRollEnd()
    {
        _character.Rotator.Enabled = true;
        _character.Mover.StopDirectionalMovement();
    }
}