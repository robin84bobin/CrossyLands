using System.Threading.Tasks;
using UnityEngine;
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

        public async Task<string> LoadTextFile(string path)
        {
            var handle = Addressables.LoadAssetAsync<TextAsset>(path);
            var t =  await handle.Task;
            return t.text;
        }
    }
}