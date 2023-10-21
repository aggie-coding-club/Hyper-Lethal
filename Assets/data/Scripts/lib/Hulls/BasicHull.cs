using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHull : Hull
{
    // Update is called once per physics frame
    public override void FixedUpdate()
    {
        updateHull();
    }
}
