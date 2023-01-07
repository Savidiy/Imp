using UniRx;
using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class NearInteractableChecker : ITickable
    {
        private readonly IInteractablesHolder _interactableHolder;
        private readonly ImpSettings _impSettings;
        private readonly Transform _impTransform;

        private readonly ReactiveProperty<Interactable> _nearInteractable = new();

        public bool HasNearInteractable { get; private set; }
        public IReadOnlyReactiveProperty<Interactable> NearInteractable => _nearInteractable;

        public NearInteractableChecker(IInteractablesHolder interactableHolder, ImpGameObject impGameObject, ImpSettings impSettings)
        {
            _interactableHolder = interactableHolder;
            _impSettings = impSettings;
            _impTransform = impGameObject.transform;
        }

        public void Tick()
        {
            Interactable nearestInteractable = null;
            float minimalSquareDistance = float.MaxValue;

            foreach (Interactable pickupable in _interactableHolder.Interactables)
            {
                Vector3 deltaPosition = pickupable.transform.position - _impTransform.position;
                deltaPosition.z = 0;
                float sqrMagnitude = deltaPosition.sqrMagnitude;
                if (sqrMagnitude < _impSettings.InteractSquareDistance && sqrMagnitude < minimalSquareDistance)
                {
                    nearestInteractable = pickupable;
                    minimalSquareDistance = sqrMagnitude;
                }
            }

            HasNearInteractable = nearestInteractable != null;
            _nearInteractable.Value = nearestInteractable;
        }
    }
}