using CodeBase.Extensions;
using CodeBase.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI {
    [RequireComponent(typeof(Button))]
    public class StartButton: MonoBehaviour {
        private Button _button;
        private ISceneLoadService _sceneLoadService;

        [Inject]
        public void Construct(ISceneLoadService sceneLoadService) {
            _sceneLoadService = sceneLoadService;
        }
        
        private void Awake() => _button = GetComponent<Button>();
        private void OnEnable() => _button.Subscribe(StartQuiz);
        private void OnDisable() => _button.Unsubscribe(StartQuiz);

        private void StartQuiz() {
            _sceneLoadService.LoadAsync("Quiz");
        }
    }
}