using ECS.Components;
using ECS.Components.Events;
using ECS.Gravity;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputJumpComponent, GroundCheckComponent> _jumpFilter = null;
        private EcsFilter<PlayerInputMoveComponent> _moveFilter = null;
        
        public void Run()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            foreach (var index in _moveFilter)
            {
                ref var inputHero = ref _moveFilter.Get1(index);
                inputHero.Direction = new Vector3(x, y);
            }
        }

        private void Jump()
        {
            var jump = Input.GetKeyDown(KeyCode.Space);
            if (!jump)
                return;
            
            foreach (var i in _jumpFilter)
            {
                var groundCheck = _jumpFilter.Get2(i);
                if (!groundCheck.IsGrounded)
                    continue;
                
                ref var entity = ref _jumpFilter.GetEntity(i);
                ref var jumpEvent = ref entity.Get<JumpEvent>();
                jumpEvent.Value = 0.01f;
            }
        }
    }
}