using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuView : MonoBehaviour
{
    [Inject] public ISceneLoadingService _sceneLoadingService;
    
    [SerializeField] private Button _startButton;

    void Start()
    {
        _startButton.onClick.AddListener(StartClickHandler);
    }

    private void StartClickHandler()
    {
        _sceneLoadingService.Load("GameScene");
    }

    void OnDestroy()
    {
        _startButton.onClick.AddListener(StartClickHandler);
    }
}
