namespace Imp
{
    internal sealed class QuestTarget
    {
        public EItemId ItemId { get; }
        public int CurrentCount { get; private set; }
        public int TargetCount { get; }
        public bool IsCompleted => CurrentCount == TargetCount;

        public QuestTarget(EItemId itemId, int targetCount)
        {
            ItemId = itemId;
            CurrentCount = 0;
            TargetCount = targetCount;
        }

        public void AddOne()
        {
            CurrentCount++;
        }
    }
}