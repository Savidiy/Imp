using System;
using System.Collections.Generic;

namespace Imp
{
    internal class ImpInventory
    {
        private readonly List<Item> _items = new List<Item>();
        private readonly ImpSettings _impSettings;

        public IReadOnlyList<Item> Items => _items;
        public bool IsFull => _items.Count >= Size;
        public int Size => _impSettings.InventorySize;

        public event Action InventoryUpdated;

        public ImpInventory(ImpSettings impSettings)
        {
            _impSettings = impSettings;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            InventoryUpdated?.Invoke();
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
            InventoryUpdated?.Invoke();
        }
    }
}