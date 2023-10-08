using UnityEngine;
using Zenject;

namespace Services
{
    public class AppServicesStarter : MonoBehaviour
    {
        [Inject] public ISceneLoadingService SceneLoadingService { get; }
        
        //TODO make via IInitializable
        private void Start()
        {
            DontDestroyOnLoad(this);
            //TODO init services
            SceneLoadingService.Load("StartScene");
        }
    }
}