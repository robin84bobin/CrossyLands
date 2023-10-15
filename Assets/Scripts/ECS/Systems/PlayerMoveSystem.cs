using ECS;
using Leopotam.Ecs;
using UnityEngine;

internal class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<MoveComponent, PlayerInputComponent> _moveFilter = null;
    
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