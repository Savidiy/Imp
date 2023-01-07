using UniRx;
using UnityEngine;

namespace Imp
{
    internal sealed class PickUpUIDrawer : MonoBehaviour
    {
        [SerializeField] private Transform _pickUpInfoUI;
        [SerializeField] private Vector3 _infoShift;
        
        private PickUpChecker _pickUpChecker;

        private void Start()
        {
            _pickUpChecker = FindObjectOfType<PickUpChecker>();
            _pickUpChecker.SelectedPickUp.Subscribe(OnSelectedPickUpChange);
        }

        private void OnSelectedPickUpChange(Pickupable pickupable)
        {
            _pickUpInfoUI.gameObject.SetActive(_pickUpChecker.HasSelectedPickUp);
            
            if (!_pickUpChecker.HasSelectedPickUp)
                return;

            Vector3 position = pickupable.transform.position;
            position += _infoShift;
            _pickUpInfoUI.position = position;
        }
    }
}