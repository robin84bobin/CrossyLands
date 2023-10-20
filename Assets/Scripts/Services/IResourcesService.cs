using System.Threading.Tasks;
using Installers.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public interface IResourcesService
    {
        void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single);
        Task<string> LoadTextFile(string path);
        Task<T> LoadComponentFromPrefab<T>(string path) where T:UnityEngine.Object;
    }
}