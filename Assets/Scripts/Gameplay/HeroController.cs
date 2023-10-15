using UnityEngine;
using Zenject;

namespace Installers.Gameplay
{
    public class HeroController : MonoBehaviour
    {
        private BaseGameplayInputService _inputService;
        [Inject] private HeroModel _heroModel;
        
        private void Start()
        {
        }

        private void OnDestroy()
        {
        }
    }
}