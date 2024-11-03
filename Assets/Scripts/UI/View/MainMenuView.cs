using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace View
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton1;
        [SerializeField] private Button _startButton2;
        [SerializeField] private Button _startButton3;
        
        private IMainMenuPresenter _presenter;

        [Inject]
        public void Construct(IMainMenuPresenter presenter)
        {
            _presenter = presenter;
        }
        
        void Start()
        {
            _startButton1.onClick.AddListener(() => StartClickHandler(1));
            _startButton2.onClick.AddListener(() => StartClickHandler(2));
            _startButton3.onClick.AddListener(() => StartClickHandler(3));
        }

        private void StartClickHandler(int i)
        {
            _presenter.OnLoadLevelClick(i);
        }

        

        void OnDestroy()
        {
            _startButton1.onClick.RemoveAllListeners();
            _startButton2.onClick.RemoveAllListeners();
            _startButton3.onClick.RemoveAllListeners();
        }
    }
}
