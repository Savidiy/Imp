using System.Collections.Generic;

namespace Imp
{
    internal sealed class Quest
    {
        private readonly List<QuestTarget> _targets;
        public bool IsCompleted { get; private set; }

        public Quest(List<QuestTarget> targets)
        {
            _targets = targets;
        }

        public void AddItem(Item item)
        {
            foreach (QuestTarget target in _targets)
            {
                if (target.IsCompleted)
                    continue;

                if (target.ItemId != item.ItemId)
                    continue;

                target.AddOne();
                CheckCompleting();
                return;
            }
        }

        private void CheckCompleting()
        {
            foreach (QuestTarget questTarget in _targets)
            {
                if (!questTarget.IsCompleted)
                {
                    IsCompleted = false;
                    return;
                }
            }

            IsCompleted = true;
        }
    }
}