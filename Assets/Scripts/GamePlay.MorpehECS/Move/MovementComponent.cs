using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace ECS.Morpeh.Move
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct MovementComponent : IComponent {
        public float moveStepValue;
        public float moveStepDuration;
        public float gravity;
        //
        
        public Transform transform;
        public Vector3 StartPosition;
        public Vector3 Destination;
        public float startTime;
        public float moveTime;
        public bool isMoving;

        public void SetupMove(Vector3 direction)
        {
            StartPosition = transform.position;
            Destination = StartPosition + Vector3.Normalize(direction) * moveStepValue;
            startTime = Time.time;
            moveTime = moveStepDuration;
            isMoving = true;
        }

        public void StopMove()
        {
            Debug.Log($"StopMove : {Time.time - startTime}");
            
            StartPosition = transform.position;
            Destination = StartPosition;
            startTime = 0;
            isMoving = false;
        }
    }
}