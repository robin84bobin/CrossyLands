using Core.Core.Services;
using View;

namespace UI.Presenter
{
    public class MainMenuPresenter : IMainMenuPresenter
    {
        private readonly IGameplayLevelService _gameplayLevelService;

        public MainMenuPresenter(IGameplayLevelService gameplayLevelService)
        {
            _gameplayLevelService = gameplayLevelService;
        }

        public void OnLoadLevelClick(int levelId)
        {
            _gameplayLevelService.StartLevel(levelId);
        }
    }
}