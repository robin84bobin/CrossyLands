using UnityEngine;

namespace ECS
{
    public struct JumpComponent
    {
        public bool IsJumping;
        public Transform Transform { get; set; }
    }
}