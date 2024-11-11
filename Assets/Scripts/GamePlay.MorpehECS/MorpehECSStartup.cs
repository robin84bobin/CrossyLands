using System;
using Core.Core.Services;
using Core.Core.Services.ResourceService;
using ECS.Morpeh.Input;
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
        void OnEnable() {
            if (World.Default != null) {
                _group = World.Default.CreateSystemsGroup();

                //_group.AddInitializer(initializer);

                _group.AddSystem(new InputMoveSystem(_inputService));

                World.Default.AddSystemsGroup(0, this._group);
            }
        }

        protected void OnDisable() {
            if (World.Default != null) { 
                
                //_group.RemoveInitializer(initializer);

                _group.RemoveSystem(new InputMoveSystem(_inputService));

                World.Default.RemoveSystemsGroup(_group);
            }
            _group = null;
        }
    }
}