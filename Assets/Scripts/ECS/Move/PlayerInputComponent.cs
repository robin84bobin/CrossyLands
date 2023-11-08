using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct PlayerInputComponent
    {
        public Vector3 Direction;
        [HideInInspector] public double timeBlocked;
    }
}