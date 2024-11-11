using System;
using UnityEngine;

namespace GamePlay.LeoECS.Gravity
{
    [Serializable]
    public struct GroundCheckComponent
    {
        public LayerMask groundMask;
        public Transform groundCheckSphere;
        public float groundDistance;
        [NonSerialized] public bool IsGrounded;
    }
}