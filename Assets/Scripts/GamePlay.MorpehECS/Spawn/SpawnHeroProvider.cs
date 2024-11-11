using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;

namespace GamePlay.MorpehECS.Spawn
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class SpawnHeroProvider : MonoProvider<SpawnHeroComponent> {
    }
}