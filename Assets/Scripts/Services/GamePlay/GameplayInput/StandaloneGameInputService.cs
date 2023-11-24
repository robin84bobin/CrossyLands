using System;
using UnityEngine;

namespace Services.GameplayInput
{
    public class StandaloneGameInputService : IGameInputService
    {
        public Vector2 GetMoveDirection() => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}