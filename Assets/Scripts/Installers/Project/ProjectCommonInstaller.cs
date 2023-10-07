using Services;
using Zenject;

namespace Installers.Project
{
    public class ProjectCommonInstaller : MonoInstaller 
    {
        public override void InstallBindings()
        {
            //bind:
            Container.Bind<ISceneLoadingService>().To<SceneLoadingService>().AsSingle().NonLazy();
            //data service
            //resources service
            //etc.
        }

    }
}