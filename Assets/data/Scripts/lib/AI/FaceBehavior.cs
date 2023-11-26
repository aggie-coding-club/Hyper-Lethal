using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceBehavior : Steering
{
    // Start is called before the first frame update
    public override SteeringData GetSteering(SteeringBehaviorBase
    steeringbase)
    {
        Rigidbody2D rb2D_self =  GetComponent<Rigidbody2D>();

        Engine engine = GetComponent<Engine>();

        SteeringData steering = new SteeringData();

        if (!Target) return steering;

        Vector2 delta = Target.transform.position - transform.position;
        float angle =90 - Mathf.Rad2Deg*Mathf.Atan2(delta.y, delta.x) + rb2D_self.rotation;

        if (Mathf.Abs(angle) > 180)
            angle-=Mathf.Sign(angle)*360;
        
        steering.angular = Mathf.Sign(angle)*engine.MaxAngVel;
        return steering;
    }
}