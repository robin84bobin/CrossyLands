using ECS.Systems;
using Installers.Gameplay;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class ECSStartup : MonoBehaviour
{
    [Inject] private HeroController _hero;
    private EcsWorld _world;
    private EcsSystems _systems;

    void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems.Add(new GameInitSystem(_hero));
        
        _systems.Init();
    }

    void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}
