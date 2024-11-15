using Core.Core.Services;
using Core.Core.Services.ResourceService;
using UnityEngine.SceneManagement;

namespace CommonServices
{
    public class SceneService : ISceneService
    {
        private readonly IResourcesService _resourcesService;

        public SceneService(IResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
        }
        public void LoadLevelScene(int levelId)
        {
            _resourcesService.LoadScene(AppConstants.Scenes.Game);
            
            var levelSceneName = AppConstants.Scenes.Level + levelId;
            _resourcesService.LoadScene(levelSceneName, LoadSceneMode.Additive);
        }
    }
}