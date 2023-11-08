using ECS.Components;
using Leopotam.Ecs;
using Services.GameplayInput;
using UnityEngine;

namespace ECS.Input
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly BaseGameplayInputService _inputService;
        private readonly EcsFilter<PlayerInputComponent> _moveFilter = null;

        public PlayerInputSystem(BaseGameplayInputService inputService)
        {
            _inputService = inputService;
        }

        public void Run()
        {
            foreach (var index in _moveFilter)
            {
                ref var inputMoveComponent = ref _moveFilter.Get1(index);
                if (inputMoveComponent.timeBlocked > 0)
                {
                    inputMoveComponent.timeBlocked -= Time.deltaTime;
                    continue;
                }
                
                ProcessMove(ref inputMoveComponent);
            }
        }

        private void ProcessMove(ref PlayerInputComponent playerInputComponent)
        {
            var axis = Vector3.Normalize(_inputService.GetAxisValues());
            if (axis.x == 0 && axis.y == 0) 
                return;

            var direction = new Vector3(axis.x, 0, axis.y);
            playerInputComponent.Direction = direction;
            playerInputComponent.timeBlocked = 1;
        }

    }
}