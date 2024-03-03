using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class InputManager
{
    public static AInput CurrentInput => new KeyBoardInput();
    public static AMouseInput CurrentMouseInput => new MouseInput();
}
