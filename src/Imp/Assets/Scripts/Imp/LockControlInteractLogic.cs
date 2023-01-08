using UnityEngine;
using Zenject;

namespace Imp
{
    [RequireComponent(typeof(Interactable))]
    internal sealed class LockControlInteractLogic : MonoBehaviour, IInteractLogic
    {
        private ImpControlLocker _impControlLocker;

        [Inject]
        public void Construct(ImpControlLocker impControlLocker)
        {
            _impControlLocker = impControlLocker;
        }

        public void Interact(Interactable interactable)
        {
            _impControlLocker.LockControls();
        }
    }
}