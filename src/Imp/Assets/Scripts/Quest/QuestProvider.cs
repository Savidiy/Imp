using System.Collections.Generic;

namespace Imp
{
    internal sealed class QuestProvider
    {
        private readonly List<QuestData> _levelQuestData;
        private int questIndex = 0;

        public bool HasNextQuest => questIndex < _levelQuestData.Count;

        public QuestProvider(LevelQuestData levelQuestData)
        {
            _levelQuestData = levelQuestData.Data;
        }
        
        public Quest GetNextQuest()
        {
            List<TargetData> questData = _levelQuestData[questIndex].Targets;
            questIndex++;

            List<QuestTarget> targets = new();

            for (int i = 0; i < questData.Count; i++)
            {
                EItemId itemId = questData[i].itemId;
                int count = questData[i].Count;
                var questTarget = new QuestTarget(itemId, count);
                targets.Add(questTarget);
            }

            var quest = new Quest(targets);
            return quest;
        }
    }
}