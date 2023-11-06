using System;
using System.Numerics;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace ECS.Systems
{
    internal class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, PlayerInputMoveComponent> _moveInputFilter = null;
        private EcsFilter<MoveComponent> _moveFilter = null;
    
        public void Run()
        {
            ProcessInput();
            Move();
        }

        private void ProcessInput()
        {
            foreach (var index in _moveInputFilter)
            {
                ref var moveComponent = ref _moveInputFilter.Get1(index);
                ref var input = ref _moveInputFilter.Get2(index);
                moveComponent.Velocity += input.Direction * Time.deltaTime;
                //reset input after use
                input.Direction = Vector3.zero;
            }
        }

        private void Move()
        {
            foreach (var index in _moveFilter)
            {
                ref var moveComponent = ref _moveFilter.Get1(index);
                moveComponent.characterController.Move(moveComponent.Velocity);
                moveComponent.Velocity.x = 0;
                moveComponent.Velocity.z = 0;
            }
        }
    }
}