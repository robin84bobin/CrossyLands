using System;
using UnityEngine;
using Zenject;

namespace Installers.Gameplay
{
    public class HeroController : MonoBehaviour
    {
        [Inject] private BaseGameplayInputService _inputService;
        [Inject] private IHeroModel _heroModel;
        private void Start()
        {
            _inputService.OnJump += JumpEventHandler;
            _inputService.OnMove += MoveEventHandler;
        }

        private void OnDestroy()
        {
            _inputService.OnJump -= JumpEventHandler;
            _inputService.OnMove -= MoveEventHandler;
        }

        private void MoveEventHandler(Vector3 obj)
        {
            throw new NotImplementedException();
        }

        private void JumpEventHandler(Vector3 obj)
        {
            transform.Translate(obj);
        }
    }
}