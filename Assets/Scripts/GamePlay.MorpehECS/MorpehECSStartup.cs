using System;
using Core.Core.Services;
using Core.Core.Services.ResourceService;
using GamePlay.MorpehECS.InputMove;
using GamePlay.MorpehECS.Move;
using GamePlay.MorpehECS.Spawn;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Zenject;

namespace ECS.Morpeh
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class MorpehECSStartup : MonoBehaviour
    {
        [Inject] private IGameplayLevelService _gameplayLevelService;
        [Inject] private IResourcesService _resourcesService;
        [Inject] private IGameInputService _inputService;

        private SystemsGroup _group;
        private SpawnHeroSystem _spawnHeroSystem;
        private InputMoveSystem _inputMoveSystem;
        private MoveSystem _moveSystem;

        private void Awake()
        {
            _spawnHeroSystem = new SpawnHeroSystem(_resourcesService, _gameplayLevelService.HeroPrefabName);
            _inputMoveSystem = new InputMoveSystem(_inputService);
            _moveSystem = new MoveSystem();
        }

        void OnEnable() {
            if (World.Default != null) {
                _group = World.Default.CreateSystemsGroup();

                // _group.AddInitializer(_initializer);

                _group.AddSystem(_spawnHeroSystem);
                _group.AddSystem(_inputMoveSystem);
                _group.AddSystem(_moveSystem);

                World.Default.AddSystemsGroup(0, this._group);
            }
        }

        protected void OnDisable() {
            if (World.Default != null) { 
                
                //_group.RemoveInitializer(initializer);

                _group.RemoveSystem(_spawnHeroSystem);
                _group.RemoveSystem(_inputMoveSystem);
                _group.RemoveSystem(_moveSystem);
                
                World.Default.RemoveSystemsGroup(_group);
            }
            _group = null;
        }

        void Update()
        {
            World.Default?.Update(Time.deltaTime);
        }

        void FixedUpdate()
        {
            World.Default?.FixedUpdate(Time.fixedDeltaTime);
        }

        void LateUpdate()
        {
            if (World.Default != null)
            {
                World.Default.LateUpdate(Time.deltaTime);
                World.Default.CleanupUpdate(Time.deltaTime);
            }
        }
    }
}