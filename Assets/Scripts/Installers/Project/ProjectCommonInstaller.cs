﻿using Data;
using Data.Catalog;
using Data.User;
using Services;
using UnityEngine;
using Zenject;

namespace Installers.Project
{
    public class ProjectCommonInstaller : MonoInstaller 
    {
        [SerializeField] private ProjectConfig _config;

        public override void InstallBindings()
        {
            BindResourcesService();
            BindDataProxies();
            BindDataRepositories();
        }

        private void BindResourcesService()
        {
            Container.Bind<IResourcesService>().To<UnityResourcesService>().AsSingle().NonLazy();
        }

        private void BindDataProxies()
        {
            Container.Bind<IDataBaseProxy>().To<JsonDbProxy>().WithArguments(_config.CatalogPath, _config.CatalogRoot)
                .WhenInjectedInto<CatalogDataRepository>();
            Container.Bind<IDataBaseProxy>().To<JsonDbProxy>().WithArguments(_config.UserRepositoryPath, _config.CatalogRoot)
                .WhenInjectedInto<UserDataRepository>();
        }

        private void BindDataRepositories()
        {
            Container.Bind<CatalogDataRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<UserDataRepository>().AsSingle();
        }
    }
}