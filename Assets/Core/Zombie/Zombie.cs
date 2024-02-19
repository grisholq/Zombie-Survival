using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private ZombieTargetSearcher _targetSearcher;
    [SerializeField] private ZombieAttack _attacker;
    [SerializeField] private ZombieAnimator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _attackDistance = 0.5f;

    public ZombieState CurrentState { get; private set; }
    public Character Target { get; private set; }

    private RepeatTimer _targetSearchTimer = new(0.5f);
    private RepeatTimer _attackTimer = new(0.5f);

    private void Update()
    {
        HandleState();   
    }

    private void HandleState()
    {
        switch (CurrentState)
        {
            case ZombieState.Idle:
                HandleIdleState();
                break;
            case ZombieState.Persuit:
                HandlePersuitState();
                break;
            case ZombieState.Attack:
                HandleAttackState();
                break;
            default:
                break;
        }
    }

    private void HandleIdleState()
    {
        if(_targetSearchTimer.DoneWithReset && _targetSearcher.TryFindCharacterAround(out Character character))
        {
            EnterPersuitState(character);
        }
    }

    private void EnterPersuitState(Character character)
    {
        Target = character;
        CurrentState = ZombieState.Persuit;
        _agent.SetDestination(Target.transform.position);
    }

    private void HandlePersuitState()
    {
        _agent.SetDestination(Target.transform.position);
        LookAtCharacter();

        if (CloseToTargetCharacter())
        {
            EnterAttackState(); 
        }
    }

    private void EnterAttackState()
    {
        CurrentState = ZombieState.Attack;
    }

    private void HandleAttackState()
    {
        if(_attackTimer.DoneWithReset)
        {
            _attacker.Attack();
            _animator.Punch();
        }

        LookAtCharacter();

        if (AwayFromTargetCharacter())
        {
            EnterPersuitState(Target);
        }
    }

    private bool CloseToTargetCharacter()
    {
        return DistanceToTargetCharacter() <= _attackDistance;
    }

    private bool AwayFromTargetCharacter()
    {
        return DistanceToTargetCharacter() > _attackDistance;
    }

    private float DistanceToTargetCharacter()
    {
        var myPos = transform.position;
        var target = Target.transform.position;

        myPos.y = target.y;

        return Vector3.Distance(myPos, target);
    }

    private void LookAtCharacter()
    {
        if (Target == null) return;

        Vector3 start = transform.position;
        Vector3 end = Target.transform.position;

        var direction = (end - start).normalized;
        var angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

        var eulers = transform.localEulerAngles;
        eulers.y = -1 * angle;
        transform.localEulerAngles = eulers;

        
    }
}