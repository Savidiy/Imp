using UnityEngine;

namespace Imp
{
    internal class ItemsFactory
    {
        private readonly ItemsSpriteData _itemsSpriteData;

        public ItemsFactory(ItemsSpriteData itemsSpriteData)
        {
            _itemsSpriteData = itemsSpriteData;
        }
        
        public Item Create(EItemId itemId)
        {
            Sprite sprite = _itemsSpriteData.GetSprite(itemId);
            return new Item(itemId, sprite);
        }
    }
}