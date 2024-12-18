﻿using Core.Core.Services;
using UnityEngine;

namespace GameServices.GamePlay.GameplayInput
{
    public class StandaloneGameInputService : IGameInputService
    {
        public Vector2 GetInputMoveDirection() => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        public void Tick()
        {
            ReadInputValues();
        }

        public void LateTick()
        {
            DropInputValues();
        }

        private void ReadInputValues()
        {
            
        }

        private void DropInputValues()
        {
        }
    }
}