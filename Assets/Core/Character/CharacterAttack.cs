using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _range;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private CharacterAnimator _characterAnimator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (SphereOverlap.FindAround(_attackPoint.position, _range, out IDamagable damagable))
        {
            damagable.Damage(_damage);
        }

        _characterAnimator.MeleeWeaponHit();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _range);
    }
}