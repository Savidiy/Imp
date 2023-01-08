using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class WitchPresenter : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private List<Sprite> _sprites;
        
        private QuestHolder _questHolder;
        private int _spriteIndex;

        [Inject]
        public void Construct(QuestHolder questHolder)
        {
            _questHolder = questHolder;
            _questHolder.QuestUpdated += OnQuestUpdated;
            UpdateProgress();
        }

        private void OnQuestUpdated()
        {
            if (!_questHolder.HasQuest)
                return;

            bool questIsCompleted = _questHolder.Quest.IsCompleted;
            if (questIsCompleted)
                UpdateProgress();
        }

        private void UpdateProgress()
        {
            _spriteRenderer.sprite = _sprites[_spriteIndex];
            _spriteIndex++;
        }

        private void OnDestroy()
        {
            _questHolder.QuestUpdated -= OnQuestUpdated;
        }
    }
}