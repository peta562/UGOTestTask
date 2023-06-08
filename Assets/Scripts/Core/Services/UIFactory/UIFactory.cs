using Game;
using Game.UI;

namespace Core.Services.UIFactory {
    public class UIFactory : IUIFactory {
        readonly GameUIHolder _gameUIHolder;

        public UIFactory(GameUIHolder gameUIHolder) {
            _gameUIHolder = gameUIHolder;
        }

        public StartMenuView GetStartMenuView() => _gameUIHolder.StartMenuView;
        public MainGameView GetMainGameView() => _gameUIHolder.MainGameView;
        public WinsLosesView GetWinsLosesView() => _gameUIHolder.WinsLosesView;
        public GameOverView GetGameOverView() => _gameUIHolder.GameOverView;
    }
}