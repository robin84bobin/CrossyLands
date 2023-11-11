using UnityEngine;

namespace Services.GameplayInput
{
    public interface IGameInputService
    {
         Vector2 GetMoveDirection();
         bool GetJump();
    }
}