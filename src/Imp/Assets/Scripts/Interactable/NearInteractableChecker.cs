using UniRx;
using UnityEngine;

namespace Imp
{
    public class NearInteractableChecker : MonoBehaviour
    {
        [SerializeField] private Transform _impTransform;
        [SerializeField] private float _interactSquareDistance = 0.2f;
        private InteractablesHolder _interactableHolder;

        private readonly ReactiveProperty<Interactable> _nearInteractable = new();

        public bool HasNearInteractable { get; private set; }
        public IReadOnlyReactiveProperty<Interactable> NearInteractable => _nearInteractable;

        private void Start()
        {
            _interactableHolder = FindObjectOfType<InteractablesHolder>();
        }

        private void Update()
        {
            Interactable nearestInteractable = null;
            float minimalSquareDistance = float.MaxValue;

            foreach (Interactable pickupable in _interactableHolder.Interactables)
            {
                Vector3 deltaPosition = pickupable.transform.position - _impTransform.position;
                deltaPosition.z = 0;
                float sqrMagnitude = deltaPosition.sqrMagnitude;
                if (sqrMagnitude < _interactSquareDistance && sqrMagnitude < minimalSquareDistance)
                {
                    nearestInteractable = pickupable;
                    minimalSquareDistance = sqrMagnitude;
                }
            }

            if (_nearInteractable.Value == nearestInteractable)
                return;

            HasNearInteractable = nearestInteractable != null;
            _nearInteractable.Value = nearestInteractable;
        }
    }
}