using Core.Services.UIFactory;
using Game.Logic;
using Game.UI;

namespace Core.StateMachine {
    public class GameOverState : IPayloadedState<bool> {
        readonly GameStateMachine _gameStateMachine;
        readonly IUIFactory _uiFactory;

        GameOverView _gameOverView;

        public GameOverState(GameStateMachine gameStateMachine, IUIFactory uiFactory) {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
        }

        public void Enter(bool isWin) {
            _gameOverView = _uiFactory.GetGameOverView();

            var status = isWin ? "Вы победили" : "Вы проиграли";
            _gameOverView.Init(status);
            _gameOverView.RestartButtonClicked += OnRestartButtonClicked;
        }

        public void Exit() {
            _gameOverView.DeInit();
            _gameOverView.RestartButtonClicked -= OnRestartButtonClicked;
        }

        void OnRestartButtonClicked() {
            _gameStateMachine.Enter<MainGameState, MainGameController>(null);
        }
    }
}