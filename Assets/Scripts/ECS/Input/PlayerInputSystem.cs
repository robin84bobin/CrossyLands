using ECS.Components;
using ECS.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputJumpComponent> _jumpFilter = null;
        private EcsFilter<PlayerInputMoveComponent> _inputFilter = null;
        
        public void Run()
        {
            Move();
            Jump();
        }

        private void Jump()
        {
            var jump = Input.GetKeyDown(KeyCode.Space);
            if (!jump)
                return;
            
            foreach (var i in _jumpFilter)
            {
                ref var entity = ref _jumpFilter.GetEntity(i);
                ref var jumpEvent = ref entity.Get<JumpEvent>();
                jumpEvent.Value = 0.05f;
            }
        }

        private void Move()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            foreach (var index in _inputFilter)
            {
                ref var inputHero = ref _inputFilter.Get1(index);
                inputHero.Direction = new Vector3(x, y);
            }
        }
    }
}