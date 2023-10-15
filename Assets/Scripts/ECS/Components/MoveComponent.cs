using UnityEngine;

namespace ECS
{
    public struct MoveComponent
    {
        public float Speed;
        public bool IsMoving;
        public Transform Transform { get; set; }
    }
}