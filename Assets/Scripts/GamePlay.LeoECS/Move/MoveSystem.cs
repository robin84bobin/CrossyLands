using Leopotam.Ecs;
using UnityEngine;

namespace GamePlay.LeoECS.Move
{
    internal class MoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent> _filter = null;
    
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var moveComponent = ref _filter.Get1(index);
                Move(ref moveComponent);
            }
        }

        private void Move(ref MoveComponent moveComponent)
        {
            if (!moveComponent.isMoving)
                return;
            
            Transform transform = moveComponent.transform;
            
            float value = (Time.time - moveComponent.startTime) / moveComponent.moveTime;
            transform.position = Vector3.Lerp(moveComponent.StartPosition, moveComponent.Destination, value);

            if (moveComponent.Destination == transform.position)
                moveComponent.StopMove();
        }
    }
}