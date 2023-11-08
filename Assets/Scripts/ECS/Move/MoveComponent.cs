using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct MoveComponent
    {
        public float gravity;
        public Transform transform;
        [NonSerialized] public Vector3 Destination;
        [NonSerialized] public float startTime;
        [NonSerialized] public float moveTime;
    }
}