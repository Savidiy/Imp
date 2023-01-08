using System;

namespace Imp
{
    internal sealed class QuestHolder
    {
        private readonly QuestProvider _questProvider;

        public bool HasQuest { get; private set; }
        public Quest Quest { get; private set; }
        public event Action QuestUpdated;

        public QuestHolder(QuestProvider questProvider)
        {
            _questProvider = questProvider;
        }
        
        public void ActivateNextQuest()
        {
            if (!_questProvider.HasNextQuest)
            {
                HasQuest = false;
                return;
            }
                
            Quest = _questProvider.GetNextQuest();
            HasQuest = true;
            QuestUpdated?.Invoke();
        }

        public void AddItem(Item item)
        {
            Quest.AddItem(item);
            QuestUpdated?.Invoke();
        }
    }
}