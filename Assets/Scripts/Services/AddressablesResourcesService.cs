using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Services
{
    public class AddressablesResourcesService : IResourcesService
    {
        public async void LoadScene(string sceneName, LoadSceneMode mode)
        {
            var handle = Addressables.LoadSceneAsync(sceneName, mode);
            await handle.Task;
        }

        public string LoadTextFile(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}