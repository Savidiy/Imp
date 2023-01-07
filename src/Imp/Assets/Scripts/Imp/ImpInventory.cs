using System.Collections.Generic;
using UnityEngine;

namespace Imp
{
    internal class ImpInventory : MonoBehaviour
    {
        private int _size = 3;
        private readonly List<Item> _items = new List<Item>();

        public bool IsFull => _items.Count == _size;

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}