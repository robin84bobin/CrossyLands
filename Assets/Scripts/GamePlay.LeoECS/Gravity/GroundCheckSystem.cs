using Leopotam.Ecs;
using UnityEngine;

namespace GamePlay.LeoECS.Gravity
{
    sealed class GroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GroundCheckComponent> groundFilter = null;
        
        public void Run()
        {
            foreach (var i in groundFilter)
            {
                ref var groundCheck = ref groundFilter.Get1(i);

                groundCheck.IsGrounded =
                    Physics.CheckSphere(groundCheck.groundCheckSphere.position, groundCheck.groundDistance, 
                        groundCheck.groundMask);
            }
        }
    }
}