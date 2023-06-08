using Core.Services.UIFactory;
using Game.UI;

namespace Core.StateMachine {
    public class StartMenuState : IState {
        readonly GameStateMachine _gameStateMachine;
        readonly IUIFactory _uiFactory;
        
        StartMenuView _startMenuView;

        public StartMenuState(GameStateMachine gameStateMachine, IUIFactory uiFactory) {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }

        public void Enter() {
            _startMenuView = _uiFactory.GetStartMenuView();
            
            _startMenuView.Init();
            _startMenuView.StartButtonClicked += OnStartButtonClicked;
        }

        public void Exit() {
            _startMenuView.DeInit();
            _startMenuView.StartButtonClicked -= OnStartButtonClicked;
        }

        void OnStartButtonClicked() {
            _gameStateMachine.Enter<InitGameState>();
        }
    }
}