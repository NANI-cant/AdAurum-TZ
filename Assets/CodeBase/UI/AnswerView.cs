using System;
using CodeBase.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI {
    [RequireComponent(typeof(Button))]
    public class AnswerView: MonoBehaviour {
        [SerializeField] private TMP_Text _text;
        
        private Button _button;
        private bool _isCorrect;

        public event Action<bool> Selected;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() {
            _button.Subscribe(Select);
            _button.interactable = true;
        }

        private void OnDisable() {
            _button.Unsubscribe(Select);
            _button.interactable = false;
        }

        public void Setup(string text, bool isCorrect) {
            _text.text = text;
            _isCorrect = isCorrect;
        }

        private void Select() => Selected?.Invoke(_isCorrect);
    }
}