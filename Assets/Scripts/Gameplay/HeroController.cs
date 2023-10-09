using System;
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
            _inputService = _heroModel.InputService;
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