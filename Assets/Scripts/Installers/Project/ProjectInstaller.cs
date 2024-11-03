using CommonServices;
using Core.Core.Data.Proxy;
using Core.Core.Services;
using Core.Core.Services.ResourceService;
using Data.Catalog;
using Data.User;
using GameServices.GamePlay;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace Installers.Project
{
    public class ProjectInstaller : MonoInstaller 
    {
        [SerializeField] private ProjectConfig _config;

        public override void InstallBindings()
        {
            BindResourcesService();
            BindDataProxies();
            BindDataRepositories();
            BindServices();
            
        }

        private void BindServices()
        {
            Container.Bind<ISceneService>().To<SceneService>().AsSingle();
            Container.Bind<IGameplayLevelService>().To<GameplayLevelService>().AsSingle();
        }

        private void BindResourcesService()
        {
            Container.Bind<IResourcesService>().To<AddressablesResourcesService>()
                .AsSingle().NonLazy();
            Container.Bind<IResourcesService>().To<UnityResourcesService>().AsSingle()
                .WhenInjectedInto<UserDataRepository>().NonLazy();
        }

        private void BindDataProxies()
        {
            Container.Bind<IDataProxyService>().To<JsonDataProxyService>().WithArguments(_config.CatalogPath, _config.CatalogRoot)
                .WhenInjectedInto<CatalogDataRepository>();
            Container.Bind<IDataProxyService>().To<JsonDataProxyService>().WithArguments(_config.UserRepositoryPath, _config.CatalogRoot)
                .WhenInjectedInto<UserDataRepository>();
        }

        private void BindDataRepositories()
        {
            Container.Bind<CatalogDataRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<UserDataRepository>().AsSingle();
        }
    }
}