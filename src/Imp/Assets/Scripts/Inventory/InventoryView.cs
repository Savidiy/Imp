using System.Collections.Generic;
using UnityEngine;

namespace Imp
{
    internal sealed class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _itemsRoot;
        [SerializeField] private ItemView _itemViewPrefab;

        private readonly List<ItemView> _itemViews = new();

        public void UpdateItems(IReadOnlyList<Item> items, int inventorySize)
        {
            CorrectViewCount(inventorySize);
            UpdateViews(items);
        }

        private void CorrectViewCount(int inventorySize)
        {
            for (int i = _itemViews.Count - 1; i >= inventorySize; i--)
            {
                Destroy(_itemViews[i].gameObject);
                _itemViews.RemoveAt(i);
            }

            for (int i = _itemViews.Count; i < inventorySize; i++)
            {
                ItemView itemView = Instantiate(_itemViewPrefab, _itemsRoot);
                _itemViews.Add(itemView);
            }
        }

        private void UpdateViews(IReadOnlyList<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                _itemViews[i].SetupView(items[i]);
            }
            
            for (var i = items.Count; i < _itemViews.Count; i++)
            {
                _itemViews[i].SetupEmptyView();
            }
        }
    }
}