using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GamePlay.MorpehECS.Move
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class MoveSystem : ISystem {
        public World World { get; set; }
        private Filter _filter;

        public void OnAwake()
        {
            _filter = World.Filter.With<MoveComponent>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var moveComponent = ref entity.GetComponent<MoveComponent>();
                Move(ref moveComponent);
            }
        }

        private void Move(ref MoveComponent moveComponent)
        {
            if (!moveComponent.IsMoving)
                return;
            
            Transform transform = moveComponent.transform;
            
            float value = (Time.time - moveComponent.StartTime) / moveComponent.MoveTime;
            transform.position = Vector3.Lerp(moveComponent.StartPosition, moveComponent.Destination, value);

            if (moveComponent.Destination == transform.position)
                moveComponent.StopMove();
        }
    
    
        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}