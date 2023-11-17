using CodeBase.Infrastructure;
using CodeBase.Quiz;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Architecture {
    public class StartState: AState {
        private readonly QuizStateMachine _stateMachine;
        private readonly IQuestionQueue _questionQueue;
        private readonly IQuestionGenerator _questionGenerator;
        private readonly IUiService _uiService;
        private readonly Canvas _uiRoot;

        public StartState(
            QuizStateMachine stateMachine,
            IQuestionQueue questionQueue,
            IQuestionGenerator questionGenerator,
            IUiService uiService,
            Canvas uiRoot
        ) {
            _stateMachine = stateMachine;
            _questionQueue = questionQueue;
            _questionGenerator = questionGenerator;
            _uiService = uiService;
            _uiRoot = uiRoot;
        }

        public override void Enter(object payload = null) {
            _questionQueue.Setup(_questionGenerator.Generate());
            _uiService.SetRoot(_uiRoot);
            
            _stateMachine.TranslateTo<AnsweringState>();
        }
    }
}