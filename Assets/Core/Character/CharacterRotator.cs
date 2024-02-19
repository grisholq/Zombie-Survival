using Zenject;
using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Transform _view;

    public bool Enabled { get; set; } = true;

    private void Update()
    {
        if (Enabled == false) return;

        HandleRotationInMoveDirection();
    }

    public void HandleRotationInMoveDirection()
    {
        if (_character.Input.IsZero) return;
        if (Enabled == false) return;

        var direction = _character.Input.Direction;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 eulers = _view.eulerAngles;
        eulers.y = -angle;
        _view.eulerAngles = eulers;
    }
}
