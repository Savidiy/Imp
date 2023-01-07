using UnityEngine;
using Zenject;

namespace Imp
{
    [RequireComponent(typeof(Interactable))]
    internal sealed class ExecuteQuestInteractLogic : MonoBehaviour, IInteractLogic
    {
        private ImpInventory _impInventory;
        private QuestHolder _questHolder;

        [Inject]
        public void Construct(QuestHolder questHolder, ImpInventory impInventory)
        {
            _questHolder = questHolder;
            _impInventory = impInventory;
        }

        public void Interact(Interactable interactable)
        {
            foreach (Item item in _impInventory.Items)
            {
                _questHolder.AddItem(item);
            }

            _impInventory.Clear();
        }
    }
}