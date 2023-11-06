using System;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    internal class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, PlayerInputMoveComponent> _moveInputFilter = null;
        private EcsFilter<MoveComponent> _moveFilter = null;
    
        public void Run()
        {
            ProcessGravity();
            ProcessInput();
            Move();
        }

        private void ProcessGravity()
        {
            foreach (var index in _moveFilter)
            {
                ref var moveComponent = ref _moveFilter.Get1(index);
                moveComponent.Velocity = new Vector3(0, moveComponent.gravity, 0);
            }
        }

        private void ProcessInput()
        {
            foreach (var index in _moveInputFilter)
            {
                ref var moveComponent = ref _moveInputFilter.Get1(index);
                var input = _moveInputFilter.Get2(index);
                moveComponent.Velocity += input.Direction;
            }
        }

        private void Move()
        {
            foreach (var index in _moveFilter)
            {
                ref var moveComponent = ref _moveFilter.Get1(index);
                moveComponent.characterController.Move(moveComponent.Velocity);
            }
        }
    }
}