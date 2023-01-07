using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class ImpMove : IFixedTickable
    {
        private readonly ImpSettings _impSettings;
        private readonly Transform _transform;
        private readonly ImpGameObject _impGameObject;

        public ImpMove(ImpGameObject impGameObject, ImpSettings impSettings)
        {
            _impSettings = impSettings;
            _impGameObject = impGameObject;
        }

        public void FixedTick()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            Vector3 position = _impGameObject.transform.position;
            float deltaTime = Time.fixedDeltaTime;

            float deltaX = horizontal * _impSettings.WalkSpeed * deltaTime;
            float positionX = position.x + deltaX;
            float deltaY = vertical * _impSettings.WalkSpeed * deltaTime;
            float positionY = position.y + deltaY;

            _impGameObject.Rigidbody2D.MovePosition(new Vector2(positionX, positionY));
            _impGameObject.Rigidbody2D.transform.position = new Vector3(positionX, positionY, positionY);
        }
    }
}