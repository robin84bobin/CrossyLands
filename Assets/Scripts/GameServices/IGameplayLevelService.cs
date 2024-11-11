namespace Core.Core.Services
{
    public interface IGameplayLevelService
    {
        string HeroPrefabName { get; }
        void StartLevel(int levelId);
    }
}