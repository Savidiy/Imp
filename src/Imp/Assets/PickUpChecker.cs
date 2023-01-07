using System;
using UniRx;
using UnityEngine;

namespace Imp
{
    public class PickUpChecker : MonoBehaviour
    {
        [SerializeField] private Transform _impTransform;
        [SerializeField] private float _pickupSquareDistance;
        private PickupablesHolder _pickupableHolder;

        private readonly ReactiveProperty<Pickupable> _selectedPickUp = new();

        public bool HasSelectedPickUp { get; private set; }
        public IReadOnlyReactiveProperty<Pickupable> SelectedPickUp => _selectedPickUp;

        private void Start()
        {
            _pickupableHolder = FindObjectOfType<PickupablesHolder>();
        }

        private void Update()
        {
            Pickupable nearestPickupable = null;
            float minimalSquareDistance = float.MaxValue;

            foreach (Pickupable pickupable in _pickupableHolder.Pickupables)
            {
                Vector3 deltaPosition = pickupable.transform.position - _impTransform.position;
                deltaPosition.z = 0;
                float sqrMagnitude = deltaPosition.sqrMagnitude;
                if (sqrMagnitude < _pickupSquareDistance && sqrMagnitude < minimalSquareDistance)
                {
                    nearestPickupable = pickupable;
                    minimalSquareDistance = sqrMagnitude;
                }
            }

            if (_selectedPickUp.Value == nearestPickupable)
                return;

            HasSelectedPickUp = nearestPickupable != null;
            _selectedPickUp.Value = nearestPickupable;
        }
    }
}