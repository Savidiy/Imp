using System;
using System.Collections.Generic;
using UnityEngine;

namespace Imp
{
    [CreateAssetMenu(fileName = "ItemsSpriteData", menuName = "Static Data/Create ItemsSpriteData", order = 0)]
    internal class ItemsSpriteData : ScriptableObject
    {
        public Sprite _defaultSprite;
        public List<ItemSpriteData> _data;

        public Sprite GetSprite(EItemId itemId)
        {
            if (_data == null)
                return _defaultSprite;

            for (var index = 0; index < _data.Count; index++)
            {
                ItemSpriteData itemSpriteData = _data[index];
                if (itemSpriteData.ItemId == itemId)
                    return itemSpriteData.Sprite;
            }

            return _defaultSprite;
        }

        [Serializable]
        internal class ItemSpriteData
        {
            public EItemId ItemId;
            public Sprite Sprite;
        }
    }
}