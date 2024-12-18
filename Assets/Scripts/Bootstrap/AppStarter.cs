using CommonServices;
using Core.Core.Commands;
using Core.Core.Data.Commands;
using Core.Core.Services.ResourceService;
using Data.Catalog;
using Data.User;
using UnityEngine;
using Zenject;

namespace Bootstrap
{
    public class AppStarter : MonoBehaviour
    {
        [Inject] private IResourcesService _resourcesService;
        [Inject] private CatalogDataRepository _catalogRepository;
        [Inject] private UserDataRepository _userRepository;

        private CommandSequence _commandSequence;
    
        void Start()
        {
            _commandSequence = new CommandSequence(
                new InitDataRepositoryCommand(_catalogRepository),
                new InitDataRepositoryCommand(_userRepository)
            );
            _commandSequence.OnComplete += OnInitComplete;
            _commandSequence.OnProgress += OnInitProgress;
            _commandSequence.Execute();
        }

        private void OnInitProgress(float percent)
        {
            Debug.Log($"{this} : {percent * 100} %");
        }

        private void OnInitComplete()
        {
            _commandSequence.OnProgress -= OnInitProgress;
            _commandSequence.OnComplete -= OnInitComplete;
            _resourcesService.LoadScene(AppConstants.Scenes.Start);
        }
    
    }
}
