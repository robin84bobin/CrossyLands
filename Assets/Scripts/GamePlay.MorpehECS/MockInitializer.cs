using Scellecs.Morpeh;

namespace GamePlay.MorpehECS
{
    internal class MockInitializer : IInitializer
    {
        public void Dispose()
        {
        }

        public void OnAwake()
        {
        }

        public World World { get; set; }
    }
}