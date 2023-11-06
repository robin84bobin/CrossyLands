using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct PlayerInputMoveComponent
    {
        public Vector3 Direction;
    }
}