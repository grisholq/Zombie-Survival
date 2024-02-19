using Zenject;
using UnityEngine;

public class GlobalInput : MonoBehaviour
{
    [SerializeField] private InputType _inputType;

    public Vector2 MovementDirection
    {
        get
        {
            switch (_inputType)
            {
                case InputType.PC:
                    return GetPCMovementDirection();
                case InputType.Mobile:
                    return _joystick.Direction;
            }

            return GetPCMovementDirection();
        }
    }

    [Inject] private Joystick _joystick;

    private Vector2 GetPCMovementDirection()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}

public enum InputType
{
    PC,
    Mobile
}