using System;
using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class ImpMove : IFixedTickable
    {
        private readonly ImpSettings _impSettings;
        private readonly Transform _transform;
        private readonly ImpGameObject _impGameObject;
        private EMoveState _lastMoveDirection = EMoveState.WalkRight;
        private bool _isLocked;

        public EMoveState MoveState { get; private set; } = EMoveState.Idle;

        public ImpMove(ImpGameObject impGameObject, ImpSettings impSettings)
        {
            _impSettings = impSettings;
            _impGameObject = impGameObject;
        }

        public void FixedTick()
        {
            if (_isLocked)
                return;
            
            Vector2 inputVector = GetInputVector();
            MoveImp(inputVector);
            FindMoveState(inputVector);
        }

        private static Vector2 GetInputVector()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            var inputVector = new Vector2(horizontal, vertical);
            if (inputVector.sqrMagnitude > 1f)
                inputVector.Normalize();

            return inputVector;
        }

        private void MoveImp(Vector2 inputVector)
        {
            Vector3 position = _impGameObject.transform.position;
            float deltaTime = Time.fixedDeltaTime;

            float deltaX = inputVector.x * _impSettings.WalkSpeed * deltaTime;
            float positionX = position.x + deltaX;
            float deltaY = inputVector.y * _impSettings.WalkSpeed * deltaTime;
            float positionY = position.y + deltaY;

            _impGameObject.Rigidbody2D.MovePosition(new Vector2(positionX, positionY));
            _impGameObject.Rigidbody2D.transform.position = new Vector3(positionX, positionY, positionY);
        }

        private void FindMoveState(Vector2 inputVector)
        {
            const float epsilon = 0.01f;
            if (Math.Abs(inputVector.x) < epsilon && Math.Abs(inputVector.y) < epsilon)
                MoveState = EMoveState.Idle;
            else if (inputVector.x < -epsilon)
                MoveState = _lastMoveDirection = EMoveState.WalkLeft;
            else if (inputVector.x > epsilon)
                MoveState = _lastMoveDirection = EMoveState.WalkRight;
            else
                MoveState = _lastMoveDirection;
        }

        public void Lock() => _isLocked = true;
        public void Unlock() => _isLocked = false;
    }
}