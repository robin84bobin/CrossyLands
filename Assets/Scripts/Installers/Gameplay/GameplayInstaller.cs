using Services.GameplayInput;
using UnityEngine;
using Zenject;

namespace Installers.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject inputServicePrefab;

        public override void InstallBindings()
        {
            InstantiateInput();
        }

        private void InstantiateInput()
        {
            var inputService =
                Container.InstantiatePrefabForComponent<StandaloneBaseGameplayInputService>(inputServicePrefab, transform);

            Container.Bind<BaseGameplayInputService>().FromComponentOn(inputService.gameObject).AsSingle();
        }
    }
}