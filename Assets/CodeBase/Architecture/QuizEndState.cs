using CodeBase.Extensions;
using CodeBase.Quiz;
using CodeBase.SceneManagement;
using CodeBase.UI;

namespace CodeBase.Architecture {
    public class QuizEndState : AState {
        private const string MainMenuSceneName = "MainMenu";
        
        private readonly IAnswersCounter _answersCounter;
        private readonly ISceneLoadService _sceneLoadService;
        private readonly IUiService _uiService;

        private ResultScreen _resultScreen;

        public QuizEndState(
            IAnswersCounter answersCounter,
            ISceneLoadService sceneLoadService,
            IUiService uiService
        ) {
            _answersCounter = answersCounter;
            _sceneLoadService = sceneLoadService;
            _uiService = uiService;
        }
        
        public override void Enter(object payload = null) {
            _resultScreen = _uiService.OpenScreen<ResultScreen>();
            _resultScreen.Setup(_answersCounter.CorrectCount, _answersCounter.TotalCount);
            _resultScreen.StartNewGame += StartNewGame;
        }

        public override void Exit() {
            _resultScreen.StartNewGame -= StartNewGame;
            _uiService.CloseScreen(_resultScreen);
            _resultScreen = null;
        }

        private void StartNewGame() {
            _sceneLoadService.LoadAsync(MainMenuSceneName);
        }
    }
}