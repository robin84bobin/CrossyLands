using Services.GamePlay;
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
            BindInput();
        }

        private void BindInput()
        {
            Container.Bind<IGameInputService>().To<MobileGameInputService>().AsSingle();
            // Container.Bind<IGameInputService>().To<StandaloneGameInputService>().AsSingle();
        }
    }
}