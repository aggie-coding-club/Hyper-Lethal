using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEngine : Engine
{
    // Update is called once per physics frame
    public override void FixedUpdate()
    {   
        updateMovement();
    }
}
