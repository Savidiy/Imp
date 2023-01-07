using UniRx;
using UnityEngine;

namespace Imp
{
    internal sealed class InteractInfoDrawer : MonoBehaviour
    {
        [SerializeField] private GameObject _interactInfoPrefab;
        [SerializeField] private Vector3 _infoShift;
        
        private NearInteractableChecker _nearInteractableChecker;
        private GameObject _infoUI;

        private void Start()
        {
            _infoUI = Instantiate(_interactInfoPrefab);
            _nearInteractableChecker = FindObjectOfType<NearInteractableChecker>();
            _nearInteractableChecker.NearInteractable.Subscribe(OnSelectedPickUpChange);
        }

        private void OnSelectedPickUpChange(Interactable interactable)
        {
            _infoUI.SetActive(_nearInteractableChecker.HasNearInteractable);
            
            if (!_nearInteractableChecker.HasNearInteractable)
                return;

            Vector3 position = interactable.BubblePosition.position;
            position += _infoShift;
            _infoUI.transform.position = position;
        }
    }
}