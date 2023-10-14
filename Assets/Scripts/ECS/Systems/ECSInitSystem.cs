using Installers.Gameplay;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        private readonly GameObject _heroGameObject;
        private EcsWorld _world;

        public GameInitSystem(HeroController controller)
        {
            _heroGameObject = controller.gameObject;
        }
        
        public void Init()
        {
            var player = _world.NewEntity();
            ref var moveComponent = ref player.Get<MoveComponent>();
            
            ref var jumpComponent = ref player.Get<JumpComponent>();
            jumpComponent.Transform = _heroGameObject.transform;
        }
    }
}