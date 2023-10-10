using Commands;
using Commands.Startup;
using Common;
using Data.Catalog;
using Data.User;
using Services;
using UnityEngine;
using Zenject;

public class AppStarter : MonoBehaviour
{
    [Inject] private IResourcesService _resourcesService;
    [Inject] private CatalogDataRepository _catalogRepository;
    [Inject] private UserDataRepository _userRepository;

    private CommandSequence _commandSequence;
    
    void Start()
    {
        //TODO try to make Task.WaitAll(taskList)
        
        _commandSequence = new CommandSequence(
            new InitDataCommand(_catalogRepository),
            new InitDataCommand(_userRepository)
        );
        _commandSequence.OnComplete += OnInitComplete;
        _commandSequence.Execute();
    }

    private void OnInitComplete()
    {
        _commandSequence.OnComplete -= OnInitComplete;
        _resourcesService.LoadScene(AppConstants.Scenes.Start);
    }
}
