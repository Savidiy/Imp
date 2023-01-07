using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Imp
{
    internal sealed class ImpAnimator : ITickable, IDisposable
    {
        private readonly ImpMove _impMove;
        private readonly AnimationDataProvider _animationDataProvider;
        private readonly AnimationPlayer _animationPlayer;
        private EMoveState _currentMoveState = EMoveState.None;
        private readonly SpriteRenderer _spriteRenderer;

        public ImpAnimator(ImpMove impMove, AnimationDataProvider animationDataProvider, AnimationPlayer animationPlayer,
            ImpGameObject impGameObject)
        {
            _impMove = impMove;
            _animationDataProvider = animationDataProvider;
            _animationPlayer = animationPlayer;
            _spriteRenderer = impGameObject.SpriteRenderer;

            _animationPlayer.SetTarget(_spriteRenderer);
            _animationPlayer.LoopCompleted += OnLoopCompleted;
        }

        public void Tick()
        {
            if (_currentMoveState == _impMove.MoveState)
                return;

            _currentMoveState = _impMove.MoveState;
            AnimationData data = _currentMoveState switch
            {
                EMoveState.Idle => _animationDataProvider.GetData(GetRandomIdleAnimation()),
                EMoveState.WalkLeft => _animationDataProvider.GetData(EAnimationId.ImpWalk),
                EMoveState.WalkRight => _animationDataProvider.GetData(EAnimationId.ImpWalk),
                _ => throw new ArgumentOutOfRangeException()
            };

            _animationPlayer.Play(data);

            if (_currentMoveState == EMoveState.WalkLeft)
                _spriteRenderer.flipX = true;

            if (_currentMoveState == EMoveState.WalkRight)
                _spriteRenderer.flipX = false;
        }

        private void OnLoopCompleted()
        {
            if (_impMove.MoveState != EMoveState.Idle)
                return;

            AnimationData data = _animationDataProvider.GetData(GetRandomIdleAnimation());
            _animationPlayer.Play(data);
        }

        private static EAnimationId GetRandomIdleAnimation()
        {
            int range = Random.Range(0, 4);

            return range == 0 ? EAnimationId.ImpIdle2 : EAnimationId.ImpIdle1;
        }

        public void Dispose()
        {
            _animationPlayer.LoopCompleted -= OnLoopCompleted;
            _animationPlayer?.Dispose();
        }
    }
}