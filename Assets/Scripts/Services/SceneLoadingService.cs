using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneLoadingService : ISceneLoadingService
    {
        public void Load(string sceneName, LoadSceneMode mode)
        {
            SceneManager.LoadScene(sceneName, mode);
        }
    }

    public interface ISceneLoadingService
    {
        void Load(string sceneName, LoadSceneMode mode = LoadSceneMode.Single);
    }
}