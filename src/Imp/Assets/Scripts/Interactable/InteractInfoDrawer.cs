using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class InteractInfoDrawer : MonoBehaviour
    {
        [SerializeField] private GameObject _interactInfoPrefab;
        
        private NearInteractableChecker _nearInteractableChecker;
        private GameObject _infoUI;
        private IDisposable _subscribe;

        [Inject]
        public void Construct(NearInteractableChecker nearInteractableChecker)
        {
            _infoUI = Instantiate(_interactInfoPrefab);
            _nearInteractableChecker = nearInteractableChecker;
            _subscribe = _nearInteractableChecker.NearInteractable.Subscribe(OnSelectedPickUpChange);
        }
        
        private void OnSelectedPickUpChange(Interactable interactable)
        {
            _infoUI.SetActive(_nearInteractableChecker.HasNearInteractable);
            
            if (!_nearInteractableChecker.HasNearInteractable)
                return;
        
            Vector3 position = interactable.BubblePosition.position;
            _infoUI.transform.position = position;
        }

        private void OnDestroy()
        {
            _subscribe?.Dispose();
        }
    }
}