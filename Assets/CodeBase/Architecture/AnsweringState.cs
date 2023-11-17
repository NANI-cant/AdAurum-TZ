using CodeBase.Quiz;
using CodeBase.UI;
using UnityEngine.UI;

namespace CodeBase.Architecture {
    public class AnsweringState: AState {
        private readonly QuizStateMachine _stateMachine;
        private readonly Image _background;
        private readonly IQuestionQueue _questionQueue;
        private readonly IUiService _uiService;
        
        private QuestionScreen _questionScreen;

        public AnsweringState(
            QuizStateMachine stateMachine,
            Image background,
            IQuestionQueue questionQueue,
            IUiService uiService
        ) {
            _stateMachine = stateMachine;
            _background = background;
            _questionQueue = questionQueue;
            _uiService = uiService;
        }

        public override void Enter(object payload = null) {
            if (!_questionQueue.Next(out Question question)) {
                _stateMachine.TranslateTo<QuizEndState>();
                return;
            }

            _background.sprite = question.BackgroundSprite;
            _questionScreen = _uiService.OpenScreen<QuestionScreen>();
            _questionScreen.Setup(question);
            _questionScreen.AnswerSelected += EndAnswering;
        }

        public override void Exit() {
            if(_questionScreen == null) return;
            
            _questionScreen.AnswerSelected -= EndAnswering;
            _uiService.CloseScreen(_questionScreen);
            _questionScreen = null;
        }

        private void EndAnswering(bool isCorrect) {
            _stateMachine.TranslateTo<CheckAnswerState>(isCorrect);
        }
    }
}