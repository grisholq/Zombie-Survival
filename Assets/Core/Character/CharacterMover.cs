using Zenject;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;

    private Vector2 _direction;

    public enum MovementType
    {
        Input,
        Direct
    }

    public MovementType Type { get; set; } = MovementType.Input;

    private void Update()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        switch (Type)
        {
            case MovementType.Input:
                HandleInputMovement();
                break;
            case MovementType.Direct:
                HandleDirectionalMovement();
                break;
            default:
                break;
        } 
    }

    private void HandleInputMovement()
    {
        var rawVelocity = _character.Input.Direction * _speed;
        _rigidbody.velocity = new Vector3(rawVelocity.x, 0, rawVelocity.y);
    }

    private void HandleDirectionalMovement()
    {
        var rawVelocity = _direction * _speed;
        _rigidbody.velocity = new Vector3(rawVelocity.x, 0, rawVelocity.y);
    }

    public void StartDirectionalMovment()
    {
        Type = MovementType.Direct;
        _direction = _character.Input.Direction;
    }

    public void StopDirectionalMovement()
    {
        Type = MovementType.Input;
    }
}