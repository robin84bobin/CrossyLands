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
            var axis = _inputService.GetMoveDirection();
            
            foreach (var index in _moveFilter)
            {
                ref var moveComponent = ref _moveFilter.Get2(index);
                ProcessMoveInput(ref moveComponent, axis);
            }

        }

        private void ProcessMoveInput(ref MoveComponent moveComponent, Vector2 axis)
        {
            if (moveComponent.isMoving)
                return;
            
            if (axis.x == 0 && axis.y == 0) 
                return;

            var direction = new Vector3(axis.x, 0, axis.y);
            moveComponent.SetupMove(direction);
        }

    }
}