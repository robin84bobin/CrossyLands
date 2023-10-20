using System;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct PlayerInputJumpComponent
    {
        [NonSerialized]
        public bool IsJumping;
        public Transform Transform;
    }
}