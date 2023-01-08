using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Imp
{
    internal sealed class InteractablesHolder
    {
        private readonly List<Interactable> _interactables;
        public IReadOnlyList<Interactable> Interactables => _interactables;

        public InteractablesHolder()
        {
            _interactables = Object.FindObjectsOfType<Interactable>(includeInactive: true).ToList();
        }

        public void Remove(Interactable interactable)
        {
            _interactables.Remove(interactable);
            Object.Destroy(interactable.gameObject);
        }
    }
}