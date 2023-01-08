using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Imp
{
    internal sealed class QuestScrollView : MonoBehaviour
    {
        [SerializeField] private Transform _viewRoot;
        [SerializeField] private ScrollCenterView _scrollCenterViewPrefab;
        private readonly List<ScrollCenterView> _views = new();
        private Camera _camera;
        private ItemsSpriteData _itemsSpriteData;

        [Inject]
        public void Construct(ItemsSpriteData itemsSpriteData)
        {
            _itemsSpriteData = itemsSpriteData;
        }

        public void ShowQuest(Quest quest)
        {
            CorrectViewCount(quest.Targets.Count);
            UpdateViews(quest.Targets);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void UpdateViews(IReadOnlyList<QuestTarget> targets)
        {
            for (var index = 0; index < targets.Count; index++)
            {
                QuestTarget target = targets[index];
                Sprite sprite = _itemsSpriteData.GetSprite(target.ItemId);
                _views[index].SetupView(sprite, target.CurrentCount, target.TargetCount);
            }
        }

        private void CorrectViewCount(int viewCount)
        {
            for (int i = _views.Count - 1; i >= viewCount; i--)
            {
                Destroy(_views[i].gameObject);
                _views.RemoveAt(i);
            }

            for (int i = _views.Count; i < viewCount; i++)
            {
                ScrollCenterView itemView = Instantiate(_scrollCenterViewPrefab, _viewRoot);
                _views.Add(itemView);
            }
        }
    }
}