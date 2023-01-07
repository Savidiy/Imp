using UnityEngine;
using UnityEngine.UI;

namespace Imp
{
    internal class ItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        public void SetupView(Item item)
        {
            _image.sprite = item.Sprite;
            _image.gameObject.SetActive(true);
        }

        public void SetupEmptyView()
        {
            _image.gameObject.SetActive(false);
        }
    }
}