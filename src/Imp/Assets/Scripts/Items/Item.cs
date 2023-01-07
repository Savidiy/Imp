using UnityEngine;

namespace Imp
{
    internal class Item
    {
        public Sprite Sprite { get; }
        public EItemId ItemId { get; }

        public Item(EItemId itemId, Sprite sprite)
        {
            Sprite = sprite;
            ItemId = itemId;
        }
    }
}