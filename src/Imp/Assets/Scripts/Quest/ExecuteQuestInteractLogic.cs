using UnityEngine;
using Zenject;

namespace Imp
{
    [RequireComponent(typeof(Interactable))]
    internal sealed class ExecuteQuestInteractLogic : MonoBehaviour, IInteractLogic
    {
        private ImpInventory _impInventory;
        private QuestHolder _questHolder;
        private InventoryPresenter _inventoryPresenter;

        [SerializeField] private GameObject _activateWhenQuestCompleted;
        [SerializeField] private GameObject _deactivateWhenQuestCompleted;

        [Inject]
        public void Construct(QuestHolder questHolder, ImpInventory impInventory, InventoryPresenter inventoryPresenter)
        {
            _inventoryPresenter = inventoryPresenter;
            _questHolder = questHolder;
            _impInventory = impInventory;
        }

        public void Interact(Interactable interactable)
        {
            if (_impInventory.Items.Count == 0)
            {
                _inventoryPresenter.ShowWarning();
                return;
            }

            const int index = 0;

            _questHolder.AddItem(_impInventory.Items[index]);
            _impInventory.RemoveAt(index);
            
            if (_questHolder.Quest.IsCompleted)
            {
                _activateWhenQuestCompleted.SetActive(true);
                _deactivateWhenQuestCompleted.SetActive(false);
            }
        }
    }
}