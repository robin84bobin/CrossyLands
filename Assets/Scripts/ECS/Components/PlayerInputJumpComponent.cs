using UnityEngine;

namespace ECS
{
    public struct PlayerInputJumpComponent
    {
        public bool IsJumping;
        public Transform Transform { get; set; }
    }
}