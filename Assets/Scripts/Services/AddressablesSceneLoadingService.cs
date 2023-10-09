using UnityEngine.AddressableAssets;

namespace Services
{
    public class AddressablesSceneLoadingService : ISceneLoadingService
    {
        public async void Load(string sceneName)
        {
            var handle = Addressables.LoadSceneAsync(sceneName);
            await handle.Task;
        }
    }
}