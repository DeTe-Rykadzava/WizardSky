using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : AInput
{
    public override void Update()
    {
        LeftRight = Input.GetAxis("Horizontal");
        ForwardBack = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftShift))
            Sprint = true;
        else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
            Sprint = false;

        if (Input.GetKeyDown(KeyCode.Space))
            Jump = true;
        else
            Jump = false;

       
    }
    
}
