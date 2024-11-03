using ECS.Move;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Gravity
{
    public class GravityMoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent> _filter = null;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var move = ref _filter.Get1(index);
                var moveGravity = move.gravity * 2f * Time.deltaTime;
                
                var pos = move.transform.position;
                pos = new Vector3(pos.x, pos.y - moveGravity, pos.z);
                move.transform.position = pos;
            }
        }
    }
}