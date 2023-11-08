using ECS.Components;
using Leopotam.Ecs;
using Services.GameplayInput;
using UnityEngine;

namespace ECS.Input
{
    public class MoveInputSystem : IEcsRunSystem
    {
        private readonly BaseGameplayInputService _inputService;
        private readonly EcsFilter<InputMoveComponent, MoveComponent> _moveFilter = null;

        public MoveInputSystem(BaseGameplayInputService inputService)
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
            }
        }

        private void ProcessMoveInput(ref MoveComponent moveComponent)
        {
            var axis = _inputService.GetAxisValues();
            if (axis.x == 0 && axis.y == 0) 
                return;

            var direction = new Vector3(axis.x, 0, axis.y);
            moveComponent.SetupMove(direction);
        }
    }
}