using System;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct MoveComponent
    {
        public float Speed;
        [NonSerialized] 
        public bool IsMoving;

        public Transform Transform;
    }
}