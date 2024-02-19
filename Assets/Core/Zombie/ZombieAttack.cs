using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _range;
    [SerializeField] private Transform _attackPoint;

    public void Attack()
    {
        if(SphereOverlap.FindAround(_attackPoint.position, _range, out IDamagable damagable))
        {
            damagable.Damage(_damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _range);
    }
}