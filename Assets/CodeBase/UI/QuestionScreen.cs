using System;
using System.Collections.Generic;
using CodeBase.Extensions;
using CodeBase.Quiz;
using TMPro;
using UnityEngine;

namespace CodeBase.UI {
    public class QuestionScreen: MonoBehaviour {
        [SerializeField] private TMP_Text _questionText;
        [SerializeField] private AnswerView[] _answersViews;

        public event Action<bool> AnswerSelected;

        private void OnEnable() {
            foreach (var answerView in _answersViews) {
                answerView.Selected += ReactToAnswer;
            }
        }

        private void OnDisable() {
            foreach (var answerView in _answersViews) {
                answerView.Selected -= ReactToAnswer;
            }
        }

        public void Setup(Question question) {
            _questionText.text = question.QuestionText;
            
            List<Answer> answersList = question.Answers;
            answersList.Shuffle();
            for (int i = 0; i < Math.Min(_answersViews.Length, answersList.Count); i++) {
                _answersViews[i].Setup(answersList[i].Text, answersList[i].IsCorrect);
                _answersViews[i].Enable();
            }
        }

        private void ReactToAnswer(bool isCorrect) {
            AnswerSelected?.Invoke(isCorrect);
            foreach (var answersView in _answersViews) {
                answersView.Disable();
            }
        }
    }
}