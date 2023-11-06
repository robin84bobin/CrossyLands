using Leopotam.Ecs;
using Services;
using UnityEngine;

namespace ECS
{
    internal class PlayerSpawnSystem : IEcsRunSystem, IEcsPreInitSystem
    {
        private readonly IResourcesService _resourcesService;

        private EcsFilter<SpawnHeroComponent> filter = null;
        
        public PlayerSpawnSystem(IResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
        }

        public void Run()
        {
        }

        public async void PreInit()
        {
            foreach (int i in filter)
            {
                var spawnPointComponent = filter.Get1(i);

                var r = await _resourcesService.LoadPrefab("Hero");
                Object.Instantiate(r, spawnPointComponent.Transform.position, Quaternion.identity, null);
            }
        }
    }
}