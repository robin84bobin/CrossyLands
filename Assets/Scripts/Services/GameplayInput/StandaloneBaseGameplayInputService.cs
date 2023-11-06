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

    
    }
}