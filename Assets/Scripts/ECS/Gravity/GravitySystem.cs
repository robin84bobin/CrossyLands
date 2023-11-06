using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Gravity
{
    public class GravitySystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent> _filter = null;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var move = ref _filter.Get1(index);
                ref var velocity = ref move.Velocity;
                velocity.y += move.gravity * 2f * Time.deltaTime;
            }
        }
    }
}