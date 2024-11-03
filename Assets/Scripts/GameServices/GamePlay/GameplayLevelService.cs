using Core.Core.Services;

namespace GameServices.GamePlay
{
    public class GameplayLevelService : IGameplayLevelService
    {
        private readonly ISceneService _sceneService;
        
        private int _level;
        public string GetHeroPrefabName => $"Hero{_level}";

        public GameplayLevelService(ISceneService sceneService)
        {
            _sceneService = sceneService;
        }

        public void StartLevel(int levelId)
        {
            _level = levelId;
            _sceneService.LoadLevelScene(levelId);
        }
    }
}