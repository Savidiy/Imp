using System;
using UnityEngine;

namespace Imp
{
    internal sealed class AnimationPlayer : IDisposable
    {
        private readonly AnimationPlayerTicker _animationPlayerTicker;

        private AnimationData _data;
        private float _timer;
        private int _frameIndex;
        private SpriteRenderer _spriteRenderer;
        
        public event Action LoopCompleted;

        public AnimationPlayer(AnimationPlayerTicker animationPlayerTicker)
        {
            _animationPlayerTicker = animationPlayerTicker;
            _animationPlayerTicker.Ticked += Tick;
        }

        public void SetTarget(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }

        public void Play(AnimationData data)
        {
            _data = data;
            _timer = 0f;
            _frameIndex = 0;

            if (_data == null || _data.Count == 0)
                return;

            _spriteRenderer.sprite = _data[_frameIndex].Sprite;
        }

        public void Tick()
        {
            if (_data == null || _data.Count == 0)
                return;

            _timer += Time.deltaTime * _data.Speed;
            if (_timer < _data[_frameIndex].Duration)
                return;

            _timer -= _data[_frameIndex].Duration;
            _frameIndex = (_frameIndex + 1) % _data.Count;

            if (_spriteRenderer != null)
                _spriteRenderer.sprite = _data[_frameIndex].Sprite;

            if (_frameIndex == 0)
                LoopCompleted?.Invoke();
        }

        public void Dispose()
        {
            _animationPlayerTicker.Ticked -= Tick;
        }
    }
}