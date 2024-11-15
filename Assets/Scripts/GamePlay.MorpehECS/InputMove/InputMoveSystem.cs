using Core.Core.Services;
using GamePlay.MorpehECS.Move;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GamePlay.MorpehECS.InputMove
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class InputMoveSystem : ISystem
    {
        private readonly IGameInputService _inputService;
        private Filter _filter;

        public InputMoveSystem(IGameInputService inputService)
        {
            _inputService = inputService;
        }
    
        public void OnAwake()
        {
            _filter = World.Filter
                .With<InputMoveComponent>()
                .With<MoveComponent>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime) {
            if (_filter.IsEmpty())
                return;
            
            var inputDirection = _inputService.GetInputMoveDirection();
            
            foreach (var entity in _filter)
            {
                ref var moveComponent = ref entity.GetComponent<MoveComponent>();
                ProcessMoveInput(ref moveComponent, inputDirection);
            }
        }

        private void ProcessMoveInput(ref MoveComponent movementComponent, Vector2 inputDirection)
        {
            if (movementComponent.IsMoving)
                return;
            
            if (inputDirection.x == 0 && inputDirection.y == 0) 
                return;

            var direction = new Vector3(inputDirection.x, 0, inputDirection.y);
            movementComponent.SetupMove(direction);

            Debug.Log($"Process Move Input : direction = {direction}");
        }

        public void Dispose()
        {
        }
    }
}