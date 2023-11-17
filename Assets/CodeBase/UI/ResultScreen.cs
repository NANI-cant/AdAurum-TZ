using System;
using CodeBase.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI {
    public class ResultScreen: MonoBehaviour {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private Button _newGameButton;

        public event Action StartNewGame;

        private void OnEnable() => _newGameButton.Subscribe(CallStartNewGame);
        private void OnDisable() => _newGameButton.Unsubscribe(CallStartNewGame);
        
        public void Setup(uint score, uint maxPossibleScore) {
            _scoreText.text = $"{score}/{maxPossibleScore}";
        }

        private void CallStartNewGame() {
            StartNewGame?.Invoke();
        }
    }
}