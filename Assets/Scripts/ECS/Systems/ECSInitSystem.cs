using Installers.Gameplay;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        // private readonly GameObject _heroGameObject;
        private EcsWorld _world;

        public GameInitSystem(HeroController controller)
        {
            // _heroGameObject = controller.gameObject;
        }
        
        public void Init()
        {
            InitHero();
        }

        private void InitHero()
        {
            // var hero = _world.NewEntity();

            // ref var inputHeroComponent = ref hero.Get<PlayerInputMoveComponent>();

            // ref var moveComponent = ref hero.Get<MoveComponent>();
            // moveComponent.Transform = _heroGameObject.transform;

            // ref var jumpComponent = ref hero.Get<PlayerInputJumpComponent>();
            // jumpComponent.Transform = _heroGameObject.transform;
        }
    }
}