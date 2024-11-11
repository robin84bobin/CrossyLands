using Core.Core;
using Core.Core.Services;
using GamePlay.LeoECS.Move;
using Leopotam.Ecs;
using UnityEngine;

namespace GamePlay.LeoECS.Input
{
    internal class InputMoveSystem : IEcsRunSystem
    {
        private readonly IGameInputService _inputService;
        private EcsFilter<InputMoveComponent, MoveComponent> _filter = null;

        public InputMoveSystem(IGameInputService inputService)
        {
            _inputService = inputService;
        }

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var moveComponent = ref _filter.Get2(index);
                
                var inputDirection = _inputService.GetInputMoveDirection().ToRightAngleDirection();
                ProcessMoveInput(ref moveComponent, inputDirection);
            }

        }

        private void ProcessMoveInput(ref MoveComponent movementComponent, Vector2 inputDirection)
        {
            if (movementComponent.isMoving)
                return;
            
            if (inputDirection.x == 0 && inputDirection.y == 0) 
                return;

            var direction = new Vector3(inputDirection.x, 0, inputDirection.y);
            movementComponent.SetupMove(direction);
        }

    }
}