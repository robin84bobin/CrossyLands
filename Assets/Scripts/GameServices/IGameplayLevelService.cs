namespace Core.Core.Services
{
    public interface IGameplayLevelService
    {
        string GetHeroPrefabName { get; }
        void StartLevel(int levelId);
    }
}