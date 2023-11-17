using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Utils {
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(AspectRatioFitter))]
    [ExecuteInEditMode]
    public class AutoEnvelopeParent: MonoBehaviour {
        private Image _image;
        private AspectRatioFitter _aspectFitter;

        private Sprite _lastSprite;
        private float _lastRatio;

        private void Awake() {
            _image = GetComponent<Image>();
            _aspectFitter = GetComponent<AspectRatioFitter>();
        }

        private void LateUpdate() {
            if(_image.sprite == _lastSprite && Mathf.Approximately(_lastRatio, _aspectFitter.aspectRatio)) return;
            
            Sprite sprite = _image.sprite;
            
            float ratio = sprite.rect.width / sprite.rect.height;
            _aspectFitter.aspectMode = AspectRatioFitter.AspectMode.EnvelopeParent;
            _aspectFitter.aspectRatio = ratio;
            
            _lastSprite = sprite;
            _lastRatio = ratio;
        }
    }
}