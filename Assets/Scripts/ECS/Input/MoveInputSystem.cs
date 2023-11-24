using ECS.Components;
using Leopotam.Ecs;
using Services.GameplayInput;
using UnityEngine;

namespace ECS.Input
{
    public class MoveInputSystem : IEcsRunSystem
    {
        private readonly IGameInputService _inputService;
        private readonly EcsFilter<InputMoveComponent, MoveComponent> _moveFilter = null;

        public MoveInputSystem(IGameInputService inputService)
        {
            _inputService = inputService;
        }

        public void Run()
        {
            var inputDirection = _inputService.GetInputMoveDirection();
            
            foreach (var index in _moveFilter)
            {
                ref var moveComponent = ref _moveFilter.Get2(index);
                ProcessMoveInput(ref moveComponent, inputDirection);
            }

        }

        private void ProcessMoveInput(ref MoveComponent moveComponent, Vector2 inputDirection)
        {
            if (moveComponent.isMoving)
                return;
            
            if (inputDirection.x == 0 && inputDirection.y == 0) 
                return;

            var direction = new Vector3(inputDirection.x, 0, inputDirection.y);
            moveComponent.SetupMove(direction);
        }

    }
}