using ECS.Components.Events;
using ECS.Systems;
using Leopotam.Ecs;
using Services;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ECS
{
    public class ECSStartup : MonoBehaviour
    {
        [Inject] private IResourcesService _resourcesService;
        private EcsWorld _world;
        private EcsSystems _systems;

        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
        
            AddSystems();
            AddEvents();
        
            _systems.Init();
        }

        private void AddSystems()
        {
            _systems.ConvertScene();
            _systems.Add(new GameInitSystem());
            _systems.Add(new PlayerSpawnSystem(_resourcesService));
            _systems.Add(new PlayerInputSystem());
            _systems.Add(new PlayerJumpSystem());
            _systems.Add(new PlayerMoveSystem());
        }

        private void AddEvents()
        {
            _systems.OneFrame<JumpEvent>();
        }

        void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }
    }
}