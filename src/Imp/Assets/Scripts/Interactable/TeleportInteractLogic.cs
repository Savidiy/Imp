using UnityEngine;

namespace Imp
{
    [RequireComponent(typeof(Interactable))]
    internal sealed class TeleportInteractLogic : MonoBehaviour, IInteractLogic
    {
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private Vector3 _shiftAfterTeleport;
        private ImpMove _impMove;

        private void Awake()
        {
            _impMove = FindObjectOfType<ImpMove>();
        }

        public void Interact(Interactable interactable)
        {
            Vector3 position = _targetPosition.position;
            position += _shiftAfterTeleport;
            _impMove.transform.position = position;
        }
    }
}