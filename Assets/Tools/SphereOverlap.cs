using UnityEngine;
using System.Collections.Generic;

public static class SphereOverlap
{
    public static bool FindAround<T>(Vector3 position, float range, out T component) where T : class
    {
        var colliders = Physics.OverlapSphere(position, range);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out component))
            {
                return true;
            }
        }

        component = null;
        return false;
    }

    public static bool FindAllAround<T>(Vector3 position, float range, out List<T> components) where T : class
    {
        var colliders = Physics.OverlapSphere(position, range);
        components = new List<T>();

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out T component))
            {
                components.Add(component);
            }
        }

        return components.Count != 0;
    }
}