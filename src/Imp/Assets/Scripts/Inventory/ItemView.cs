using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Imp
{
    internal class ItemView : MonoBehaviour
    {
        [FormerlySerializedAs("_image")] [SerializeField] private Image _itemImage;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Color _warningColor;
        [SerializeField] private Color _defaultColor;
        [SerializeField] private float _warningDuration;
        private TweenerCore<Color, Color, ColorOptions> _tween;

        public void SetupView(Item item)
        {
            _itemImage.sprite = item.Sprite;
            _itemImage.gameObject.SetActive(true);
        }

        public void SetupEmptyView()
        {
            _itemImage.gameObject.SetActive(false);
        }

        public void ShowWarning()
        {
            _tween?.Kill(true);
            _backgroundImage.color = _warningColor;
            _tween = DOTween.To(
                () => _backgroundImage.color,
                value => _backgroundImage.color = value,
                _defaultColor,
                _warningDuration);
        }
    }
}