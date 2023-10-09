﻿using UnityEngine;
using Zenject;

namespace Installers.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _heroSpawnPoint;
        [SerializeField] private GameObject _heroPrefab;
        [SerializeField] private GameObject _inputServicePrefab;

        public override void InstallBindings()
        {
            InstantiateInput();
            
            Container.BindInterfacesTo<HeroModel>().AsCached().NonLazy();
            Container.Bind<HeroModel>().AsCached().NonLazy();
            
            InstantiateObjects();
        }

        private void InstantiateObjects()
        {
            InstantiateHero();
        }

        private void InstantiateHero()
        {
            var hero = Container.InstantiatePrefabForComponent<HeroController>(_heroPrefab, _heroSpawnPoint.transform.position,
                Quaternion.identity, null);
        }

        private void InstantiateInput()
        {
            var inputService =
                Container.InstantiatePrefabForComponent<StandaloneBaseGameplayInputService>(_inputServicePrefab, transform);

            Container.Bind<BaseGameplayInputService>().FromComponentOn(inputService.gameObject).AsSingle();
        }
    }
}