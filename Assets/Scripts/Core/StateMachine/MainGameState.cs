using System;
using Core.Services.SaveLoadService;
using Core.Services.UIFactory;
using Game.Logic;
using Game.UI;

namespace Core.StateMachine {
    public class MainGameState : IPayloadedState<MainGameController> {
        readonly GameStateMachine _gameStateMachine;
        readonly IUIFactory _uiFactory;
        readonly ISaveLoadService _saveLoadService;

        MainGameController _mainGameController;
        WinsLosesView _winsLosesView;

        public MainGameState(GameStateMachine gameStateMachine, IUIFactory uiFactory, ISaveLoadService saveLoadService) {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _saveLoadService = saveLoadService;
        }

        public void Enter(MainGameController mainGameController) {
            if ( mainGameController != null ) {
                _mainGameController = mainGameController;
            }

            _winsLosesView = _uiFactory.GetWinsLosesView();
            UpdateWinsLosesView();
            
            _mainGameController.StartGame();
            _mainGameController.GameOver += HandleGameOver;
        }

        public void Exit() {
            _mainGameController.FinishGame();
            _mainGameController.GameOver -= HandleGameOver;
        }

        void HandleGameOver(bool isWin) {
            if ( isWin ) {
                _saveLoadService.ProgressData.Wins++;
            }
            else {
                _saveLoadService.ProgressData.Loses++;
            }

            _saveLoadService.SaveData();
            UpdateWinsLosesView();

            _gameStateMachine.Enter<GameOverState, bool>(isWin);
        }

        void UpdateWinsLosesView() {
            _winsLosesView.UpdateWinsLosesText(_saveLoadService.ProgressData.Wins, _saveLoadService.ProgressData.Loses);
        }
    }
}