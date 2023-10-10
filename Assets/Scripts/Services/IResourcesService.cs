using UnityEngine.SceneManagement;

namespace Services
{
    public interface IResourcesService
    {
        void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single);
        string LoadTextFile(string path);
    }
}