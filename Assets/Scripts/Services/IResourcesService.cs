using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Services
{
    public interface IResourcesService
    {
        void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single);
        Task<string> LoadTextFile(string path);
    }
}