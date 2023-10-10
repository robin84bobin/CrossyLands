using Common;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class MainMenuView : MonoBehaviour
{
    [Inject] public IResourcesService ResourcesService;
    
    [SerializeField] private Button _startButton;

    void Start()
    {
        _startButton.onClick.AddListener(StartClickHandler);
    }

    private void StartClickHandler()
    {
        LoadLevel();
    }

    private void LoadLevel(int levelId = 1)
    {
        ResourcesService.LoadScene(AppConstants.Scenes.Game);
        var levelSceneName = AppConstants.Scenes.Level + levelId;
        ResourcesService.LoadScene(levelSceneName, LoadSceneMode.Additive);
    }

    void OnDestroy()
    {
        _startButton.onClick.RemoveListener(StartClickHandler);
    }
}
