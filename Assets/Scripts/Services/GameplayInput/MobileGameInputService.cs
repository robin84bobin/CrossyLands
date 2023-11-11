using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Services.GameplayInput
{
    public class MobileGameInputService : IGameInputService, IDisposable
    {
        private readonly InputActions _inputActions;
        private Vector2 _moveDirection;
        private float _startTouchTime;
        private Vector2 _startTouchPosition;

        public MobileGameInputService()
        {
            _inputActions = new InputActions();
            _inputActions.Mobile.Enable();

            _inputActions.Mobile.PrimaryTouchContact.started += OnPrimaryTouchStart;
            _inputActions.Mobile.PrimaryTouchContact.canceled += OnPrimaryTouchEnd;
        }

        private void OnPrimaryTouchStart(InputAction.CallbackContext context)
        {
            _startTouchTime = Time.time;
            _startTouchPosition = _inputActions.Mobile.PrimaryTouchPosition.ReadValue<Vector2>();
        }

        private void OnPrimaryTouchEnd(InputAction.CallbackContext context)
        {
            if (Time.time - _startTouchTime > 1f)
                return;

            var endTouchPosition = _inputActions.Mobile.PrimaryTouchPosition.ReadValue<Vector2>();
            if (Vector2.Distance(endTouchPosition, _startTouchPosition) < 0.2f)
                return;
            
            _moveDirection = endTouchPosition - _startTouchPosition;
        }

        public Vector2 GetMoveDirection()
        {
            Vector2 result = _moveDirection;
            _moveDirection = Vector2.zero;
            return result;
        }

        public bool GetJump()
        {
            var value = _inputActions.Mobile.PrimaryTouchContact.ReadValue<float>();
            return value != 0;
        }

        public void Dispose()
        {
            _inputActions?.Dispose();
        }
    }
}