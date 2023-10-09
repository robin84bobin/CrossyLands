using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Services
{
    public class AddressablesSceneLoadingService : ISceneLoadingService
    {
        public async void Load(string sceneName, LoadSceneMode mode)
        {
            var handle = Addressables.LoadSceneAsync(sceneName, mode);
            await handle.Task;
        }

    }
}