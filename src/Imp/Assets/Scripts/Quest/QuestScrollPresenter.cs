using System;

namespace Imp
{
    internal sealed class QuestScrollPresenter : IDisposable
    {
        private readonly QuestScrollView _questScrollView;
        private readonly QuestHolder _questHolder;

        public QuestScrollPresenter(QuestScrollView questScrollView, QuestHolder questHolder)
        {
            _questScrollView = questScrollView;
            _questHolder = questHolder;
            
            _questHolder.QuestUpdated += OnQuestUpdated;
            OnQuestUpdated();
        }

        private void OnQuestUpdated()
        {
            _questScrollView.ShowQuest(_questHolder.Quest);
        }

        public void Dispose()
        {
            _questHolder.QuestUpdated -= OnQuestUpdated;
        }
    }
}