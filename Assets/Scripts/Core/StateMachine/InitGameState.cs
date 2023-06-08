using Core.Services.ConfigProvider;
using Core.Services.UIFactory;
using Game.Logic;

namespace Core.StateMachine {
    public class InitGameState : IState {
        readonly GameStateMachine _gameStateMachine;
        readonly IUIFactory _uiFactory;
        readonly IConfigProvider _configProvider;

        public InitGameState(GameStateMachine gameStateMachine, IUIFactory uiFactory, IConfigProvider configProvider) {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _configProvider = configProvider;
        }

        public void Enter() {
            var mainGameView = _uiFactory.GetMainGameView();
            var mainConfig = _configProvider.MainConfig;
            var randomWordsGenerator = new RandomWordsGenerator(mainConfig.GuessingWords);
            
            var mainGameController =
                new MainGameController(mainGameView, mainConfig, randomWordsGenerator);
            mainGameController.Init();
            
            _gameStateMachine.Enter<MainGameState, MainGameController>(mainGameController);
        }

        public void Exit() {
            
        }
    }
}