using UniRx;
using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class NearInteractableChecker : ITickable
    {
        private readonly InteractablesHolder _interactableHolder;
        private readonly ImpSettings _impSettings;
        private readonly Transform _impTransform;

        private readonly ReactiveProperty<Interactable> _nearInteractable = new();

        public bool HasNearInteractable { get; private set; }
        public IReadOnlyReactiveProperty<Interactable> NearInteractable => _nearInteractable;

        public NearInteractableChecker(InteractablesHolder interactableHolder, ImpGameObject impGameObject, ImpSettings impSettings)
        {
            _interactableHolder = interactableHolder;
            _impSettings = impSettings;
            _impTransform = impGameObject.transform;
        }

        public void Tick()
        {
            Interactable nearestInteractable = null;
            float minimalSquareDistance = float.MaxValue;

            foreach (Interactable interactable in _interactableHolder.Interactables)
            {
                if (!interactable.gameObject.activeInHierarchy)
                    continue;

                Vector3 deltaPosition = interactable.transform.position - _impTransform.position;
                deltaPosition.z = 0;
                float sqrMagnitude = deltaPosition.sqrMagnitude;
                if (sqrMagnitude < _impSettings.InteractSquareDistance && sqrMagnitude < minimalSquareDistance)
                {
                    nearestInteractable = interactable;
                    minimalSquareDistance = sqrMagnitude;
                }
            }

            HasNearInteractable = nearestInteractable != null;
            _nearInteractable.Value = nearestInteractable;
        }
    }
}