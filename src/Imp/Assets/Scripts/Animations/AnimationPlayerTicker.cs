using System;
using Zenject;

namespace Imp
{
    internal sealed class AnimationPlayerTicker : ITickable
    {
        public event Action Ticked; 

        public void Tick()
        {
            Ticked?.Invoke();
        }
    }
}