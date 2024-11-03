using Core.Core.Services;

namespace UI.Presenter
{
    public class MainMenuPresenter
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