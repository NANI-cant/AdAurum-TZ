using CodeBase.Architecture;
using CodeBase.Extensions;
using CodeBase.Quiz.Impl;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Installers {
    public class QuizInstaller: MonoInstaller {
        [SerializeField] private Image _background;
        [SerializeField] private Canvas _uiRoot;
        
        public override void InstallBindings() {
            Container.BindService<QuestionQueue>();
            Container.BindService<QuizStateMachine>();
            Container.BindService<AnswersCounter>();
            
            Container.BindInstance(_background).AsSingle().NonLazy();
            Container.BindInstance(_uiRoot).AsSingle().NonLazy();
        }
    }
}