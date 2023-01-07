using System.Collections.Generic;
using UnityEngine;

namespace Imp
{
    internal sealed class QuestGenerator
    {
        private readonly List<EItemId> _possibleItemsId = new()
        {
            EItemId.Mushroom1, 
            EItemId.Mushroom2, 
            EItemId.Mushroom3
        };

        public Quest GenerateNewQuest()
        {
            int targetCount = Random.Range(1, 3);

            var possibleItemsId = new List<EItemId>(_possibleItemsId);

            List<QuestTarget> targets = new();

            for (int i = 0; i < targetCount; i++)
            {
                int itemIdIndex = Random.Range(0, possibleItemsId.Count);
                EItemId itemId = possibleItemsId[itemIdIndex];
                possibleItemsId.RemoveAt(itemIdIndex);

                int count = Random.Range(1, 3);
                var questTarget = new QuestTarget(itemId, count);
                targets.Add(questTarget);
            }

            var quest = new Quest(targets);
            return quest;
        }
    }
}