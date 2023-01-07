using UnityEngine;
using Zenject;

namespace Imp
{
    [RequireComponent(typeof(Interactable))]
    internal sealed class TeleportInteractLogic : MonoBehaviour, IInteractLogic
    {
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private Vector3 _shiftAfterTeleport;
        private Transform _transform;

        [Inject]
        public void Construct(ImpGameObject impGameObject)
        {
            _transform = impGameObject.transform;
        }

        public void Interact(Interactable interactable)
        {
            Vector3 position = _targetPosition.position;
            position += _shiftAfterTeleport;
            _transform.position = position;
        }
    }
}