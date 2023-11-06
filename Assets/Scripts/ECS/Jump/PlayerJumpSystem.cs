using ECS.Components;
using ECS.Components.Events;
using Leopotam.Ecs;

namespace ECS.Systems
{
    internal class PlayerJumpSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputJumpComponent, JumpEvent, MoveComponent> _jumpFilter = null;
    
        public void Run()
        {
            foreach (var i in _jumpFilter)
            {
                ref var jumpComponent = ref _jumpFilter.Get1(i);
                ref var jumpEvent = ref _jumpFilter.Get2(i);
                ref var move = ref _jumpFilter.Get3(i);

                move.Velocity.y = jumpEvent.Value;
            }
        }
    }
}