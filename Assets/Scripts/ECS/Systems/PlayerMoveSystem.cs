using ECS;
using Leopotam.Ecs;
using UnityEngine;

internal class PlayerJumpSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputJumpComponent, JumpEvent> _jumpFilter = null;
    
    public void Run()
    {
        foreach (var i in _jumpFilter)
        {
            ref var jumpComponent = ref _jumpFilter.Get1(i);
            ref var jumpEvent = ref _jumpFilter.Get2(i);

            jumpComponent.Transform.position += new Vector3(
                jumpComponent.Transform.position.x,
                jumpComponent.Transform.position.y,
                jumpComponent.Transform.position.z + jumpEvent.Value
            );
        }
    }
}
internal class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<MoveComponent, PlayerInputMoveComponent> _moveFilter = null;
    
    public void Run()
    {
        foreach (var index in _moveFilter)
        {
            ref var moveComponent = ref _moveFilter.Get1(index);
            ref var input = ref _moveFilter.Get2(index);
            moveComponent.Transform.position += input.Direction * (Time.deltaTime/* * moveComponent.Speed*/);
        }
    }
}