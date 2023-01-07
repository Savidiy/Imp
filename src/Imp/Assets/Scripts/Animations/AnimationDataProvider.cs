using System;
using System.Collections.Generic;
using UnityEngine;

namespace Imp
{
    [CreateAssetMenu(fileName = "AnimationDataProvider", menuName = "Static Data/Create AnimationDataProvider", order = 0)]
    internal sealed class AnimationDataProvider : ScriptableObject
    {
        public List<AnimationDataPair> _data;

        public AnimationData GetData(EAnimationId animationId)
        {
            foreach (AnimationDataPair animationDataPair in _data)
            {
                if (animationDataPair.AnimationId == animationId)
                    return animationDataPair.AnimationData;
            }

            throw new Exception($"Can't find animation data with id '{animationId}'");
        }
    }

    [Serializable]
    internal sealed class AnimationDataPair
    {
        public EAnimationId AnimationId;
        public AnimationData AnimationData;
    }
}