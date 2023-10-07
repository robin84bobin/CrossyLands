using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneLoadingService : ISceneLoadingService
    {
        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public interface ISceneLoadingService
    {
        void Load(string sceneName);
    }
}