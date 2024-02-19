using UnityEngine;
using UnityEngine.AI;

public class ZombieAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;

    private void Update()
    {
        _animator.SetFloat("speed", _agent.velocity.magnitude);
    }

    public void Punch()
    {
        _animator.SetTrigger("punch");
    }
}
