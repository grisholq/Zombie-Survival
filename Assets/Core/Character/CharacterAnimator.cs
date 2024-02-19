using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Animator _animator;

    private const string _running = "Running";
    private const string _roll = "Roll";

    public void Run()
    {
        _animator.SetBool(_running, true);
    }

    public void Walk()
    {
        _animator.SetBool(_running, false);
    }

    public void Roll()
    {
        _animator.SetTrigger(_roll);
    }

    public void MeleeWeaponHit()
    {
        _animator.SetTrigger("BatHit");
    }

    private void Update()
    {
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        var running = _character.Input.Magnitude > 0.1f;

        if (running) Run();
        else Walk();

        if(Input.GetKeyDown(KeyCode.B))
        {
            _animator.SetTrigger("BatHit");
        }
    }
}