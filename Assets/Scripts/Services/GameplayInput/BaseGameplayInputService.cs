using System;
using UnityEngine;

namespace Services.GameplayInput
{
    public class BaseGameplayInputService : MonoBehaviour
    {
        public event Action<Vector3> OnMove;
        public event Action<Vector3> OnJump;
    
        protected void OnJumpPressed(Vector3 value)
        {
            OnJump?.Invoke(value);
        }

        public virtual Vector2 GetAxisValues() => Vector2.zero;
        public virtual bool GetJump() => false;
    }
}