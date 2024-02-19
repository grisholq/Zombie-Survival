using Zenject;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [Inject] private GlobalInput _input;

    public Vector2 Direction => _input.MovementDirection.normalized;
    public float Magnitude => Direction.magnitude;
    public bool IsZero => Magnitude == 0;
}