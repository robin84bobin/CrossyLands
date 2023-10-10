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
        ResourcesService.LoadScene("GameScene");
        ResourcesService.LoadScene("Level 1", LoadSceneMode.Additive);
    }

    void OnDestroy()
    {
        _startButton.onClick.RemoveListener(StartClickHandler);
    }
}
