using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Imp
{
    internal sealed class ScrollCenterView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _countText;

        public void SetupView(Sprite sprite, int currentCount, int targetCount)
        {
            _image.sprite = sprite;
            _countText.text = $"{currentCount}/{targetCount}";
        }
    }
}