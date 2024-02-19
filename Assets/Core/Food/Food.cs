using UnityEngine;

public class Food : MonoBehaviour, IInteractableObject
{
    [SerializeField] private float _hungerRestore;

    public void Interact(Character character)
    {
        character.Hunger.Current += _hungerRestore;
        Destroy(gameObject);
    }
}