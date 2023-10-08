using System;
using UnityEngine;

public class BaseGameplayInputService : MonoBehaviour
{
    public event Action<Vector3> OnMove;
    public event Action<Vector3> OnJump;
    
    protected void OnJumpPressed(Vector3 value)
    {
        OnJump?.Invoke(value);
    }
}