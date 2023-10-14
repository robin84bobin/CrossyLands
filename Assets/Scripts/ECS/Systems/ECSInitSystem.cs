using Leopotam.Ecs;

namespace ECS.Systems
{
    public class GameInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;

        public void Init()
        {
            var player = _world.NewEntity();
            player.Get<MoveComponent>();
            player.Get<JumpComponent>();
        }
    }
}