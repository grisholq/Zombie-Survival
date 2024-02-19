using UnityEngine;

public class CharacterInteractionHandler : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private CharacterInteractionTrigger _interactionTrigger;

    private void Start()
    {
        _interactionTrigger.Interacted += Interact;
    }

    public void Interact(IInteractableObject interactableObject)
    {
        interactableObject.Interact(_character);
    }
}