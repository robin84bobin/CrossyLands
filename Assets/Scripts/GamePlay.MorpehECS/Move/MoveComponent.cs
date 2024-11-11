using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GamePlay.MorpehECS.Move
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct MoveComponent : IComponent {
        //move to configs
        public float moveStepValue;
        public float moveStepDuration;
        public float gravity;
        //
        
        public Transform transform;
        [NonSerialized] public Vector3 StartPosition;
        [NonSerialized] public Vector3 Destination;
        [NonSerialized] public float StartTime;
        [NonSerialized] public float MoveTime;
        [NonSerialized] public bool IsMoving;

        public void SetupMove(Vector3 direction)
        {
            StartPosition = transform.position;
            Destination = StartPosition + Vector3.Normalize(direction) * moveStepValue;
            StartTime = Time.time;
            MoveTime = moveStepDuration;
            IsMoving = true;
        }

        public void StopMove()
        {
            Debug.Log($"StopMove : {Time.time - StartTime}");
            
            StartPosition = transform.position;
            Destination = StartPosition;
            StartTime = 0;
            IsMoving = false;
        }
    }
}