using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Imp
{
    internal sealed class PickupablesHolder : MonoBehaviour
    {
        private List<Pickupable> _pickupables;
        public IReadOnlyList<Pickupable> Pickupables => _pickupables;

        private void Awake()
        {
            _pickupables = FindObjectsOfType<Pickupable>().ToList();
        }
    }
}