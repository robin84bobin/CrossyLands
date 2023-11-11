using UnityEngine;

namespace Services.GameplayInput
{
    public class StandaloneGameInputService : IGameInputService
    {
        private readonly InputActions _inputActions;
        private Vector2 _currentMoveVector;

        public StandaloneGameInputService()
        {
            _inputActions = new InputActions();
            _inputActions.Standalone.Enable();
        }

        public Vector2 GetAxisValues()
        {
            _currentMoveVector = _inputActions.Standalone.Move.ReadValue<Vector2>();
            return _currentMoveVector;
        }

        public bool GetJump()
        {
            var readValue = _inputActions.Standalone.Jump.ReadValue<float>();
            return readValue != 0f;
        }
    }
}