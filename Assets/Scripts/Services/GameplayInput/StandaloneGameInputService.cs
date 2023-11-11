using UnityEngine;
using Input = UnityEngine.Input;

namespace Services.GameplayInput
{
    public class StandaloneGameInputService : IGameInputService
    {

        public Vector2 GetAxisValues()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public bool GetJump()
        {
            return Input.GetKey(KeyCode.Space);
        }
    }
}