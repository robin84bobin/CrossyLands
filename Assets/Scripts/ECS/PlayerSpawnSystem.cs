using Installers.Gameplay;
using Leopotam.Ecs;
using Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Voody.UniLeo;

internal class PlayerSpawnSystem : IEcsRunSystem, IEcsPreInitSystem
{
    private readonly IResourcesService _resourcesService;
    private HeroController _hero;

    public PlayerSpawnSystem(IResourcesService resourcesService)
    {
        _resourcesService = resourcesService;
    }

    public void Run()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            var newHero = GameObject.Instantiate(_hero.gameObject, Vector3.zero, Quaternion.identity);
            // var instantiateComponentProvider = newHero.AddComponent<InstantiateComponentProvider>();
            // instantiateComponentProvider.Value.gameObject = newHero;
        }
    }

    public async void PreInit()
    {
        _hero = await _resourcesService.LoadComponentFromPrefab<HeroController>("Hero");
    }
}