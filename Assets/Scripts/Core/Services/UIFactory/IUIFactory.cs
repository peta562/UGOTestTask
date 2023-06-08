using Game.UI;

namespace Core.Services.UIFactory {
    public interface IUIFactory : IService {
        StartMenuView GetStartMenuView();
        MainGameView GetMainGameView();
        WinsLosesView GetWinsLosesView();
        GameOverView GetGameOverView();
    }
}