using System;

namespace Imp
{
    internal sealed class QuestHolder
    {
        private readonly QuestGenerator _questGenerator;

        public Quest Quest { get; private set; }
        public event Action QuestUpdated;

        public QuestHolder(QuestGenerator questGenerator)
        {
            _questGenerator = questGenerator;
            GenerateNewQuest();
        }

        private void GenerateNewQuest()
        {
            Quest = _questGenerator.GenerateNewQuest();
        }

        public void AddItem(Item item)
        {
            Quest.AddItem(item);
            if (Quest.IsCompleted)
                GenerateNewQuest();
            
            QuestUpdated?.Invoke();
        }
    }
}