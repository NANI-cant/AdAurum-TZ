using CodeBase.Extensions;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Impl;
using CodeBase.SceneManagement.Impl;
using CodeBase.UI;
using CodeBase.UI.Impl;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers {
    public class ProjectInstaller: MonoInstaller {
        [SerializeField] private TextAsset _jsonQuestions;
        
        public override void InstallBindings() {
            Container.BindService<JsonQuestionGenerator>();
            Container.BindService<UnitySceneLoadService>();
            Container.BindService<ResourcesAssetProvider>();
            Container.BindService<UnityInstantiateService>();
            Container.BindService<UnityDestroyService>();
            Container.BindService<UiService>();

            Container.BindInstance(_jsonQuestions).AsSingle().NonLazy();
        }
    }
}