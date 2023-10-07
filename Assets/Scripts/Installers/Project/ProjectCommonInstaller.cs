using Services;
using Zenject;

namespace Installers.Project
{
    public class ProjectCommonInstaller : MonoInstaller 
    {
        public override void InstallBindings()
        {
            //Container.BindInterfacesTo<ProjectCommonInstaller>().FromInstance(this);
            //bind:
            Container.Bind<ISceneLoadingService>().To<SceneLoadingService>().AsSingle().NonLazy();
            //data service
            //resources service
            //etc.
        }

    }
}