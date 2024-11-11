using Core.Core.Services;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace ECS.Morpeh.Input
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class InputMoveSystem : ISystem
    {
        private IGameInputService _inputService;
        private Filter _filter;
        private Stash<MoveByInputComponent> _inputComponentsStash;

    
        public InputMoveSystem(IGameInputService inputService)
        {
            _inputService = inputService;
        }
    
        public void OnAwake()
        {
            _filter = World.Filter.With<MoveByInputComponent>().Build();
            _inputComponentsStash = World.GetStash<MoveByInputComponent>();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime) {
            foreach (var entity in _filter)
            {
                ref var input = ref entity.GetComponent<MoveByInputComponent>();
            }
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}