using UnityEngine;
using UnityEngine.Events;

public class CharacterInteractionTrigger : MonoBehaviour
{
    public event UnityAction<IInteractableObject> Interacted;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IInteractableObject interactableObject))
        {
            Interacted?.Invoke(interactableObject);
        }
    }
}