using System;
using System.Collections.Generic;
using UnityEngine;

namespace Imp
{
    [CreateAssetMenu(fileName = "Animation", menuName = "Static Data/Create Sprite Animation", order = 0)]
    public class AnimationData : ScriptableObject
    {
        public float Speed = 10f;
        public List<FrameData> Data;

        public FrameData this[int frameIndex] => Data[frameIndex];
        public int Count => Data.Count;
    }

    [Serializable]
    public sealed class FrameData
    {
        public Sprite Sprite;
        public float Duration = 1f;
    }
}