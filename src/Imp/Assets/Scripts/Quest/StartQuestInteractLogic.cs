using UnityEngine;
using Zenject;

namespace Imp
{
    [RequireComponent(typeof(Interactable))]
    internal sealed class StartQuestInteractLogic : MonoBehaviour, IInteractLogic
    {
        private ImpInventory _impInventory;
        private QuestHolder _questHolder;
        private InventoryPresenter _inventoryPresenter;
        
        [SerializeField] private GameObject _activateWhenQuestsEnded;
        [SerializeField] private GameObject _activateWhenHasNextQuest;

        [Inject]
        public void Construct(QuestHolder questHolder)
        {
            _questHolder = questHolder;
        }

        public void Interact(Interactable interactable)
        {
            interactable.gameObject.SetActive(false);
            _questHolder.ActivateNextQuest();

            if (_questHolder.HasQuest)
            {
                _activateWhenHasNextQuest.SetActive(true);
            }
            else
            {
                _activateWhenQuestsEnded.SetActive(true);
            }
        }
    }
}