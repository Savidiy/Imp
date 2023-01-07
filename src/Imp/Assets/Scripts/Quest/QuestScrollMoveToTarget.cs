using UnityEngine;

namespace Imp
{
    internal sealed class QuestScrollMoveToTarget : MonoBehaviour
    {
        [SerializeField] private Transform _targetPosition;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 screenPos = _camera.WorldToScreenPoint(_targetPosition.position);
            transform.position = screenPos;
        }
    }
}