using Core.Core.Services.ResourceService;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GamePlay.MorpehECS.Spawn
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class SpawnHeroSystem : ISystem
    {
        public World World { get; set; }
    
        private readonly IResourcesService _resourcesService;
        private readonly string _heroPrefabName;
        private Filter _filter;


        public SpawnHeroSystem(IResourcesService resourcesService, string heroPrefabName)
        {
            _resourcesService = resourcesService;
            _heroPrefabName = heroPrefabName;
        }

        public async void OnAwake()
        {
            _filter = World.Filter.With<SpawnHeroComponent>().Build();
        
            foreach (var entity in _filter)
            {
                var spawnPointComponent = entity.GetComponent<SpawnHeroComponent>();
                
                var prefab = await _resourcesService.LoadPrefab(_heroPrefabName);
                Object.Instantiate(prefab, spawnPointComponent.Transform.position, Quaternion.identity, null);
            }
        }

        public void OnUpdate(float deltaTime)
        {
        }

        public void Dispose()
        {
        }
    }
}
