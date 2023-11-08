using ECS.Gravity;
using ECS.Input;
using ECS.Move;
using ECS.Systems;
using Leopotam.Ecs;
using Services;
using Services.GameplayInput;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ECS
{
    public class ECSStartup : MonoBehaviour
    {
        [Inject] private IResourcesService _resourcesService;
        [Inject] private BaseGameplayInputService _inputService;
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
            _systems.Add(new PlayerInputSystem(_inputService));
            _systems.Add(new GroundCheckSystem());
            // _systems.Add(new GravityMoveSystem());
            _systems.Add(new PlayerInputMoveSystem());
        }

        private void AddEvents()
        {
            // _systems.OneFrame<JumpEvent>();
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