using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class ImpMove : ITickable
    {
        private readonly ImpSettings _impSettings;
        private readonly Transform _transform;

        public ImpMove(ImpGameObject impGameObject, ImpSettings impSettings)
        {
            _impSettings = impSettings;
            _transform = impGameObject.transform;
        }

        public void Tick()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 position = _transform.position;
            float deltaTime = Time.deltaTime;
            position.x += horizontal * _impSettings.WalkSpeed * deltaTime;
            position.y += vertical * _impSettings.WalkSpeed * deltaTime;
            position.z = position.y;
            _transform.position = position;
        }
    }
}