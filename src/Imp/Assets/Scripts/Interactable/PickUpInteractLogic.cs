using UnityEngine;

namespace Imp
{
    internal sealed class PickUpInteractLogic : MonoBehaviour, IInteractLogic
    {
        private ImpInventory _impInventory;
        private InteractablesHolder _interactablesHolder;
        private ItemsFactory _itemsFactory;

        [SerializeField] private EItemId _itemId;

        private void Start()
        {
            _impInventory = FindObjectOfType<ImpInventory>();
            _interactablesHolder = FindObjectOfType<InteractablesHolder>();
            _itemsFactory = new ItemsFactory();
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