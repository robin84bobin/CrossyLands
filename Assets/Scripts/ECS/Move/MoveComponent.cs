using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct MoveComponent
    {
        //move to configs
        public float moveStepValue;
        public float moveStepDuration;
        public float gravity;
        //
        
        public Transform transform;
        [NonSerialized] public Vector3 StartPosition;
        [NonSerialized] public Vector3 Destination;
        [NonSerialized] public float startTime;
        [NonSerialized] public float moveTime;
        [NonSerialized] public bool isMoving;

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