using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Move
{
    internal class PlayerInputMoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, PlayerInputComponent> _filter = null;
    
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var moveComponent = ref _filter.Get1(index);
                ref var input = ref _filter.Get2(index);
                
                Transform transform = moveComponent.transform;
                
                ProcessInput(ref input, ref moveComponent, transform);
                Move(ref moveComponent, transform);
            }
        }

        private void ProcessInput(ref PlayerInputComponent input, ref MoveComponent moveComponent, Transform transform)
        {
            if (input.Direction == Vector3.zero)
                return;
           
            moveComponent.Destination = transform.position + input.Direction;
            moveComponent.startTime = Time.time;
            moveComponent.moveTime = 1f;
            
            input.Direction = Vector3.zero;
        }

        private void Move(ref MoveComponent moveComponent, Transform transform)
        {
            if (moveComponent.startTime <= 0)
                return;
            if (moveComponent.Destination == transform.position)
                return;

            float value = (Time.time - moveComponent.startTime) / moveComponent.moveTime;
            transform.position = Vector3.Slerp(transform.position, moveComponent.Destination, value);
        }
    }
}