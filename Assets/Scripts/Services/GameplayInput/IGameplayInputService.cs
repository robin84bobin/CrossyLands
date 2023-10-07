using System;
using System.Numerics;

public interface IGameplayInputService
{
    event Action<Vector3> OnMove;
    event Action<Vector3> OnJump;
}