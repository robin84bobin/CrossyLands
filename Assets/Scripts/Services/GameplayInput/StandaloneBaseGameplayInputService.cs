using UnityEngine;
using Input = UnityEngine.Input;

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