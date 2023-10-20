using System;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct PlayerInputMoveComponent
    {
        public Vector3 Direction;
    }
}