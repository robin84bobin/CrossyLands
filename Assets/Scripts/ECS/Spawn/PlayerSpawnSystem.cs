using Core.Core.Services.ResourceService;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Spawn
{
    internal class PlayerSpawnSystem : IEcsRunSystem, IEcsPreInitSystem
    {
        private readonly IResourcesService _resourcesService;
        private readonly string _heroPrefabName;
        
        private readonly EcsFilter<SpawnHeroComponent> _filter = null;
        
        public PlayerSpawnSystem(IResourcesService resourcesService, string heroPrefabName)
        {
            _resourcesService = resourcesService;
            _heroPrefabName = heroPrefabName;
        }

        public void Run()
        {
        }

        public async void PreInit()
        {
            foreach (int i in _filter)
            {
                var spawnPointComponent = _filter.Get1(i);
                
                var r = await _resourcesService.LoadPrefab(_heroPrefabName);
                Object.Instantiate(r, spawnPointComponent.Transform.position, Quaternion.identity, null);
            }
        }
    }
}