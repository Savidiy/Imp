namespace Imp
{
    internal sealed class QuestHolder
    {
        private readonly QuestGenerator _questGenerator;
        private Quest _quest;

        public QuestHolder(QuestGenerator questGenerator)
        {
            _questGenerator = questGenerator;
            GenerateNewQuest();
        }

        private void GenerateNewQuest()
        {
            _quest = _questGenerator.GenerateNewQuest();
        }

        public void AddItem(Item item)
        {
            _quest.AddItem(item);
            if (_quest.IsCompleted)
                GenerateNewQuest();
        }
    }
}