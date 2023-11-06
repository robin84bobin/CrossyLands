using ECS.Components;
using Leopotam.Ecs;

namespace ECS.Systems
{
    internal class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, PlayerInputMoveComponent> _moveFilter = null;
    
        public void Run()
        {
            foreach (var index in _moveFilter)
            {
                ref var moveComponent = ref _moveFilter.Get1(index);
                ref var input = ref _moveFilter.Get2(index);

                moveComponent.characterController.Move(input.Direction);
                moveComponent.Velocity.y += moveComponent.gravity;
            }
        }
    }
}