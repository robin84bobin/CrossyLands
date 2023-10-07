using UnityEngine;
using Zenject;

namespace Installers.Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _heroSpawnPoint;
        [SerializeField] private GameObject _heroPrefab;

        public override void InstallBindings()
        {
            //instantiate player 
            var hero = Container.
                InstantiatePrefabForComponent<HeroController>(_heroPrefab, _heroSpawnPoint.transform.position, Quaternion.identity, null);
            
            //instantiate entities 
        }
    }
}