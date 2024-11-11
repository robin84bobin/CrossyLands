using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace ECS.Morpeh.Input
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct MoveByInputComponent : IComponent
    {
        public bool IsActive;
    }
}