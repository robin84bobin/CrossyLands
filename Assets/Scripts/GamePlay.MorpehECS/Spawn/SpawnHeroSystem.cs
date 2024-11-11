using System.Collections.Generic;
using System.Threading.Tasks;
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

        private List<Vector3> spawnPositions = new List<Vector3>();
        public SpawnHeroSystem(IResourcesService resourcesService, string heroPrefabName)
        {
            _resourcesService = resourcesService;
            _heroPrefabName = heroPrefabName;
        }

        public void OnAwake()
        {
            
        }

        private async void SpawnHero()
        {
            var position = spawnPositions[0];
            spawnPositions.Clear();
            
            var t = await _resourcesService.LoadPrefab(_heroPrefabName);
            Object.Instantiate(t, position, Quaternion.identity, null);
        }

        public void OnUpdate(float deltaTime)
        {
            _filter = World.Filter.With<SpawnHeroComponent>().Build();
        
            foreach (var entity in _filter)
            {
                var spawnPointComponent = entity.GetComponent<SpawnHeroComponent>();
                
                var position = spawnPointComponent.Transform.position;
                spawnPositions.Add(position);

                entity.RemoveComponent<SpawnHeroComponent>();
            }
            
            if (spawnPositions.Count > 0)
                SpawnHero();
        }

        public void Dispose()
        {
        }
    }
}
