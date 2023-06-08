using Core.Services.SaveLoadService;

namespace Core.StateMachine {
    public class LoadProgressState : IState {
        readonly GameStateMachine _gameStateMachine;
        readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, ISaveLoadService saveLoadService) {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
        }

        public void Enter() {
            _saveLoadService.LoadData();
           
           _gameStateMachine.Enter<StartMenuState>();
        }

        public void Exit() {
            
        }
    }
}