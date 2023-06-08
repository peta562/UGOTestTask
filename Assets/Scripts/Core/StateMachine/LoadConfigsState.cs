using Core.Services.ConfigProvider;

namespace Core.StateMachine {
    public class LoadConfigsState : IState {
        readonly GameStateMachine _gameStateMachine;
        readonly IConfigProvider _configProvider;

        public LoadConfigsState(GameStateMachine gameStateMachine, IConfigProvider configProvider) {
            _gameStateMachine = gameStateMachine;
            _configProvider = configProvider;
        }

        public void Enter() {
           _configProvider.LoadConfigs();
           
           _gameStateMachine.Enter<LoadProgressState>();
        }

        public void Exit() {
            
        }
    }
}