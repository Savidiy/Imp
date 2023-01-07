using UnityEngine;
using Zenject;

namespace Imp
{
    [RequireComponent(typeof(Interactable))]
    internal sealed class PickUpInteractLogic : MonoBehaviour, IInteractLogic
    {
        private ImpInventory _impInventory;
        private IInteractablesHolder _interactablesHolder;
        private ItemsFactory _itemsFactory;

        [SerializeField] private EItemId _itemId;

        [Inject]
        public void Construct(ImpInventory impInventory, IInteractablesHolder interactablesHolder, ItemsFactory itemsFactory)
        {
            _impInventory = impInventory;
            _interactablesHolder = interactablesHolder;
            _itemsFactory = itemsFactory;
        }

        public void Interact(Interactable interactable)
        {
            if (_impInventory.IsFull)
            {
                // play beep sound
                return;
            }

            // play pickup sound
            Item item = _itemsFactory.Create(_itemId);
            _impInventory.AddItem(item);
            _interactablesHolder.Remove(interactable);
        }
    }
}