using System;
using System.Security.Cryptography.X509Certificates;

[Serializable]
public class PlayerMovementSpecifications
{
    public int MaxCountJumps = 1;
    public float Speed = 1.5f;
    public float JumpForce = 2f;
    public float JumpHeight = 1f;
    public float SprintSpeed = 2.5f;
    public float Gravity = -9.81f;
}