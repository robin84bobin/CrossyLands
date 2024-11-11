using Core.Core.Services;
using Core.Core.Services.ResourceService;
using GamePlay.LeoECS.Gravity;
using GamePlay.LeoECS.Input;
using GamePlay.LeoECS.Move;
using GamePlay.LeoECS.Spawn;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace GamePlay.LeoECS
{
    public class LeoECSStartup : MonoBehaviour
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
            _systems.Add(new PlayerSpawnSystem(_resourcesService, _gameplayLevelService.HeroPrefabName));
            _systems.Add(new InputMoveSystem(_inputService));
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
            _systems?.Destroy();
            _world?.Destroy();
        }
    }
}