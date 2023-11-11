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
            foreach (var index in _moveFilter)
            {
                ref var moveComponent = ref _moveFilter.Get2(index);
                if (moveComponent.isMoving)
                    continue;
                
                ProcessMoveInput(ref moveComponent);
                // ProcessJumpInput(ref moveComponent);
            }
        }

        private void ProcessMoveInput(ref MoveComponent moveComponent)
        {
            var axis = _inputService.GetMoveDirection();
            if (axis.x == 0 && axis.y == 0) 
                return;

            var direction = new Vector3(axis.x, 0, axis.y);
            moveComponent.SetupMove(direction);
        }

        private void ProcessJumpInput(ref MoveComponent moveComponent)
        {
            if (_inputService.GetJump())
            {
                moveComponent.transform.Translate(Vector3.up);
            }
        }
    }
}