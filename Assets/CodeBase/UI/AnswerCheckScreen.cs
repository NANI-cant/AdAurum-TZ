using System;
using CodeBase.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI {
    public class AnswerCheckScreen: MonoBehaviour {
        [SerializeField] private GameObject _correctLabel;
        [SerializeField] private GameObject _notCorrectLabel;
        [SerializeField] private Button _nextButton;

        public event Action NextQuestion;

        private void OnEnable() => _nextButton.Subscribe(CallNextQuestion);
        private void OnDisable() => _nextButton.Unsubscribe(CallNextQuestion);

        public void SetCorrect() {
            _correctLabel.Activate();
            _notCorrectLabel.Deactivate();
        }

        public void SetNotCorrect() {
            _correctLabel.Deactivate();
            _notCorrectLabel.Activate();
        }

        private void CallNextQuestion() => NextQuestion?.Invoke();
    }
}