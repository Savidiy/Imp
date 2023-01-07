using System;
using UniRx;
using UnityEngine;

namespace Imp
{
    internal sealed class InteractInfoDrawer : IDisposable
    {
        private readonly NearInteractableChecker _nearInteractableChecker;
        private readonly GameObject _interactInfo;
        private readonly IDisposable _subscribe;

        public InteractInfoDrawer(NearInteractableChecker nearInteractableChecker, InteractInfo interactInfo)
        {
            _interactInfo = interactInfo.gameObject;
            _nearInteractableChecker = nearInteractableChecker;
            _subscribe = _nearInteractableChecker.NearInteractable.Subscribe(OnSelectedPickUpChange);
        }

        private void OnSelectedPickUpChange(Interactable interactable)
        {
            _interactInfo.SetActive(_nearInteractableChecker.HasNearInteractable);

            if (!_nearInteractableChecker.HasNearInteractable)
                return;

            Vector3 position = interactable.BubblePosition.position;
            _interactInfo.transform.position = position;
        }

        public void Dispose()
        {
            _subscribe?.Dispose();
        }
    }
}