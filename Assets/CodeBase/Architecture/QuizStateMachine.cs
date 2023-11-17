using System;
using System.Collections.Generic;
using CodeBase.Infrastructure;
using CodeBase.Quiz;
using CodeBase.SceneManagement;
using CodeBase.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Architecture {
    public class QuizStateMachine: IInitializable {
        private readonly Dictionary<Type, AState> _states;
        private AState _activeState;

        public QuizStateMachine(
            IQuestionQueue questionQueue,
            IQuestionGenerator questionGenerator,
            ISceneLoadService sceneLoadService,
            IAnswersCounter answersCounter,
            Image background,
            IUiService uiService, 
            Canvas uiRoot
        ) {
            _states = new Dictionary<Type, AState>() {
                [typeof(StartState)] = new StartState(this, questionQueue, questionGenerator, uiService, uiRoot),
                [typeof(AnsweringState)] = new AnsweringState(this, background, questionQueue, uiService),
                [typeof(CheckAnswerState)] = new CheckAnswerState(this, answersCounter, uiService),
                [typeof(QuizEndState)] = new QuizEndState(answersCounter, sceneLoadService, uiService)
            };
        }

        public void TranslateTo<TState>(object payload = null) where TState: AState {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter(payload);
        }

        public void Initialize() {
            TranslateTo<StartState>();
        }
    }
}