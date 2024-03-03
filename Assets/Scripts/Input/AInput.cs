using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInput
{
    public float LeftRight { get; protected set; }

    public float ForwardBack { get; protected set; }

    public bool Jump { get; protected set; } = false;
    
    public bool Sprint { get; protected set; } = false;

   

    public abstract void Update();
}
