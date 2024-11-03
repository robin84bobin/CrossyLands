using Core.Core.Services;
using Core.Core.Services.ResourceService;
using ECS.Gravity;
using ECS.Input;
using ECS.Move;
using ECS.Spawn;
using GameServices.GamePlay;
using GameServices.GamePlay.GameplayInput;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ECS
{
    public class ECSStartup : MonoBehaviour
    {
        [Inject] private IGameplayLevelService _gameplayLevelService;
        [Inject] private IResourcesService _resourcesService;
        [Inject] private IGameInputService _inputService;
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
            _systems.Add(new PlayerSpawnSystem(_resourcesService, _gameplayLevelService.GetHeroPrefabName));
            _systems.Add(new MoveInputSystem(_inputService));
            _systems.Add(new GroundCheckSystem());
            // _systems.Add(new GravityMoveSystem());
            _systems.Add(new MoveSystem());
        }

        public void Update()
        {
            _systems.Run();
        }

        private void AddEvents()
        {
            // _systems.OneFrame<JumpEvent>();
        }


        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }
    }
}