using ECS.Systems;
using Installers.Gameplay;
using Leopotam.Ecs;
using Services;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

public class ECSStartup : MonoBehaviour
{
    [Inject] private IResourcesService _resourcesService;
    [Inject] private HeroController _hero;
    private EcsWorld _world;
    private EcsSystems _systems;

    void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        
        AddSystems();
        AddEvents();
        
        _systems.Init();
    }

    private void AddSystems()
    {
        _systems.ConvertScene();
        _systems.Add(new GameInitSystem());
        _systems.Add(new PlayerSpawnSystem(_resourcesService));
        _systems.Add(new PlayerInputSystem());
        _systems.Add(new PlayerMoveSystem());
        _systems.Add(new PlayerJumpSystem());
    }

    private void AddEvents()
    {
        _systems.OneFrame<JumpEvent>();
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