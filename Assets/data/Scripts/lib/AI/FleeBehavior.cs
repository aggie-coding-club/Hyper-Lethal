using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : Steering
{
    public override SteeringData GetSteering(SteeringBehaviorBase
    steeringbase)
    {
        SteeringData steering = new SteeringData();

        if (!Target) return steering;

        steering.linear = transform.position - Target.transform.position;
        
        steering.linear.Normalize();
        steering.linear *= steeringbase.MaxAcc;
        steering.angular = 0;
        return steering;
    }
}
