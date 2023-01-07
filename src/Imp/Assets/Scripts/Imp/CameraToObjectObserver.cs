using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class CameraToObjectObserver : ITickable
    {
        private readonly Transform _targetTransform;
        private readonly ImpSettings _impSettings;
        private readonly Camera _camera;

        public CameraToObjectObserver(ImpGameObject impGameObject, ImpSettings impSettings)
        {
            _targetTransform = impGameObject.transform;
            _impSettings = impSettings;
            _camera = Camera.main;
        }

        public void Tick()
        {
            Vector3 position = _targetTransform.position;
            Vector3 shift = _impSettings.CameraShift;
            Vector3 cameraPosition = position + shift;
            _camera.transform.position = cameraPosition;
        }
    }
}