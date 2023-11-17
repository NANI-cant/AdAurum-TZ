using System;
using System.Collections.Generic;
using CodeBase.Infrastructure;
using UnityEngine;

namespace CodeBase.UI.Impl {
    public class UiService : IUiService {
        private const string QuestionScreenAssetKey = "Prefabs/QuestionScreen";
        private const string AnswerCheckScreenAssetKey = "Prefabs/AnswerCheckScreen";
        private const string ResultScreenKey = "Prefabs/ResultScreen";

        private readonly Dictionary<Type, string> _screenKeys;

        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiateService _instantiateService;
        private readonly IDestroyService _destroyService;
        private Transform _uiRoot;

        public UiService(
            IAssetProvider assetProvider,
            IInstantiateService instantiateService,
            IDestroyService destroyService
        ) {
            _assetProvider = assetProvider;
            _instantiateService = instantiateService;
            _destroyService = destroyService;

            _screenKeys = new Dictionary<Type, string>() {
                [typeof(QuestionScreen)] = "Prefabs/QuestionScreen",
                [typeof(AnswerCheckScreen)] = "Prefabs/AnswerCheckScreen",
                [typeof(ResultScreen)] = "Prefabs/ResultScreen",
            };
        }

        public void SetRoot(Canvas uiRoot) {
            _uiRoot = uiRoot.transform;
        }

        public TScreen OpenScreen<TScreen>() where TScreen: MonoBehaviour {
            var assetKey = _screenKeys[typeof(TScreen)];
            var template = _assetProvider.Load<TScreen>(assetKey);
            var screen = _instantiateService.Instantiate(template.gameObject, _uiRoot).GetComponent<TScreen>();
            return screen;
        }

        public void CloseScreen(MonoBehaviour screen) {
            if(screen == null) return;
            _destroyService.Destroy(screen.gameObject);
        }
    }
}