using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehavior : Steering
{
    public override SteeringData GetSteering(SteeringBehaviorBase
    steeringbase)
    {
        SteeringData steering = new SteeringData();
        steering.linear = Target.transform.position - transform.position;

        if (!Target) return steering;

        steering.linear.Normalize();
        steering.linear *= steeringbase.MaxAcc;
        steering.angular = 0;
        return steering;
    }
}
