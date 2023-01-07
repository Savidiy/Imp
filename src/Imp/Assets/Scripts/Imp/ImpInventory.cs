using System.Collections.Generic;
using UnityEngine;

namespace Imp
{
    internal class ImpInventory
    {
        private readonly List<Item> _items = new List<Item>();
        private readonly ImpSettings _impSettings;

        public bool IsFull => _items.Count >= _impSettings.InventorySize;

        public ImpInventory(ImpSettings impSettings)
        {
            _impSettings = impSettings;
        }
        
        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}