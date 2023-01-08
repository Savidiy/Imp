using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class ImpInteract : ITickable
    {
        private readonly NearInteractableChecker _nearInteractableChecker;

        public ImpInteract(NearInteractableChecker nearInteractableChecker)
        {
            _nearInteractableChecker = nearInteractableChecker;
        }

        public void Tick()
        {
            if (IsKeyDown() && _nearInteractableChecker.HasNearInteractable)
            {
                Interactable interactable = _nearInteractableChecker.NearInteractable.Value;
                interactable.Interact();
            }
        }

        private static bool IsKeyDown()
        {
            return Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space);
        }
    }
}