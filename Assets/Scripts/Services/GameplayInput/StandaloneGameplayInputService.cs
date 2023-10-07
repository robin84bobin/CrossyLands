using System;
using System.Numerics;

public class StandaloneGameplayInputService : IGameplayInputService
{
    public event Action<Vector3> OnMove;
    public event Action<Vector3> OnJump;
}