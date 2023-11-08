using UnityEngine;
using Input = UnityEngine.Input;

namespace Services.GameplayInput
{
    public class StandaloneBaseGameplayInputService : BaseGameplayInputService
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                OnJumpPressed(Vector3.up);
            }
        }


        public override Vector2 GetAxisValues()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        public override bool GetJump()
        {
            return Input.GetKey(KeyCode.Space);
        }
    }
}