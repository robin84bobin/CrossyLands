using Services;
using Zenject;

namespace Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoadingService>().To<SceneLoadingService>().AsSingle();
        }
    }
}