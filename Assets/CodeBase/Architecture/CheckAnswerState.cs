using CodeBase.Extensions;
using CodeBase.Quiz;
using CodeBase.UI;

namespace CodeBase.Architecture {
    public class CheckAnswerState : AState {
        private readonly QuizStateMachine _stateMachine;
        private readonly IAnswersCounter _answersCounter;
        private readonly IUiService _uiService;

        private AnswerCheckScreen _answerCheckScreen;

        public CheckAnswerState(
            QuizStateMachine stateMachine,
            IAnswersCounter answersCounter,
            IUiService uiService
        ) {
            _stateMachine = stateMachine;
            _answersCounter = answersCounter;
            _uiService = uiService;
        }

        public override void Enter(object payload = null) {
            bool isAnswerCorrect = (bool) payload;

            _answerCheckScreen = _uiService.OpenScreen<AnswerCheckScreen>();
            if (isAnswerCorrect) {
                _answersCounter.AddCorrect();
                _answerCheckScreen.SetCorrect();    
            }
            else {
                _answersCounter.AddNotCorrect();
                _answerCheckScreen.SetNotCorrect();
            }
            
            _answerCheckScreen.NextQuestion += CallNextQuestion;
        }

        public override void Exit() {
            _answerCheckScreen.NextQuestion -= CallNextQuestion;
            _uiService.CloseScreen(_answerCheckScreen);
            _answerCheckScreen = null;
        }

        private void CallNextQuestion() {
            _stateMachine.TranslateTo<AnsweringState>();
        }
    }
}