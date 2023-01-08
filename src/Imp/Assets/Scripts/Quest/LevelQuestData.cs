using System;
using System.Collections.Generic;
using UnityEngine;

namespace Imp
{
    [CreateAssetMenu(fileName = "LevelQuestData", menuName = "Static Data/LevelQuestData", order = 0)]
    internal sealed class LevelQuestData : ScriptableObject
    {
        public List<QuestData> Data;
    }

    [Serializable]
    internal sealed class QuestData
    {
        public List<TargetData> Targets;
    }

    [Serializable]
    internal sealed class TargetData
    {
        public EItemId itemId;
        public int Count = 1;
    }
}