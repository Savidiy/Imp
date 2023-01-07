using UnityEngine;

namespace Imp
{
    internal sealed class ImpInteract : MonoBehaviour
    {
        private NearInteractableChecker _nearInteractableChecker;

        private void Start()
        {
            _nearInteractableChecker = FindObjectOfType<NearInteractableChecker>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _nearInteractableChecker.HasNearInteractable)
            {
                Interactable interactable = _nearInteractableChecker.NearInteractable.Value;
                interactable.Interact();
            }
        }
    }
}