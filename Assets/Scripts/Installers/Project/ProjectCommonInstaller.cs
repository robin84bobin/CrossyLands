using Services;
using Zenject;

namespace Installers.Project
{
    public class ProjectCommonInstaller : MonoInstaller 
    {
        public override void InstallBindings()
        {
            //bind:
            BindSceneLoadService();
            //data service
            //resources service
            //etc.
        }

        private void BindSceneLoadService()
        {
            Container.Bind<IResourcesService>().To<AddressablesResourcesService>().AsSingle().NonLazy();
        }
    }
}