using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct MoveComponent
    {
        public float gravity;
        public CharacterController characterController;
        [NonSerialized] public Vector3 Velocity;
    }
}