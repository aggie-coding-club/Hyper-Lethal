using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceVelBehavior : Steering
{
    // Start is called before the first frame update
    public override SteeringData GetSteering(SteeringBehaviorBase
    steeringbase)
    {
        Rigidbody2D rb2D =  GetComponent<Rigidbody2D>();
        Engine engine = GetComponent<Engine>();

        SteeringData steering = new SteeringData();

        Vector2 vel = rb2D.velocity;
        float angle =90 - Mathf.Rad2Deg*Mathf.Atan2(vel.y, vel.x) + rb2D.rotation;

        if (Mathf.Abs(angle) > 180)
            angle-=Mathf.Sign(angle)*360;
        
        steering.angular = Mathf.Sign(angle)*engine.maxAngVel;
        return steering;
    }
}