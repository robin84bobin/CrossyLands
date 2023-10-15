using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputComponent> _inputFilter = null;
        public void Run()
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