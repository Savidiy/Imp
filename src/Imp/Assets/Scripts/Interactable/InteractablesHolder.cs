using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Imp
{
    internal sealed class InteractablesHolder : MonoBehaviour, IInteractablesHolder
    {
        private List<Interactable> _interactables;
        public IReadOnlyList<Interactable> Interactables => _interactables;

        private void Awake()
        {
            _interactables = FindObjectsOfType<Interactable>().ToList();
        }

        public void Remove(Interactable interactable)
        {
            _interactables.Remove(interactable);
            Destroy(interactable.gameObject);
        }
    }
}