using UnityEngine;

public class ZombieTargetSearcher : MonoBehaviour
{
    [SerializeField] private float _range;

    public bool TryFindCharacterAround(out Character character)
    {
        var colliders = Physics.OverlapSphere(transform.position, _range);

        foreach (var collider in colliders)
        {
            if(collider.GetComponentInParent<Character>() != null)
            {
                character = collider.GetComponentInParent<Character>();
                return true;
            }
        }

        character = null;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}