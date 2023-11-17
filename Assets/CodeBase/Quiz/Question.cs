using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Quiz {
    public class Question {
        private readonly Answer[] _answers;
        
        public string QuestionText { get; }
        public Sprite BackgroundSprite { get; }
        public List<Answer> Answers => new (_answers);

        public Question(string questionText, Answer[] answers, Sprite backgroundSprite) {
            _answers = answers;
            BackgroundSprite = backgroundSprite;
            QuestionText = questionText;
        }
    }
}