using System;
using UnityEngine;
using Zenject;

namespace Services
{
    public class AppServices : MonoBehaviour
    {
        [Inject] public ISceneLoadingService SceneLoadingService { get; }
        [Inject] public IGameplayInputService GameplayInputService { get; }
        
        //TODO make via IInitializable
        private void Start()
        {
            DontDestroyOnLoad(this);
            //TODO init services
            SceneLoadingService.Load("StartScene");
        }
    }
}