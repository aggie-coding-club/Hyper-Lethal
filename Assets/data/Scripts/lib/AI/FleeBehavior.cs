using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : Steering
{
    [SerializeField] private GameObject target;
    public override SteeringData GetSteering(SteeringBehaviorBase
    steeringbase)
    {
        SteeringData steering = new SteeringData();
        steering.linear = transform.position - target.transform.position;
        
        steering.linear.Normalize();
        steering.linear *= steeringbase.maxAcc;
        steering.angular = 0;
        return steering;
    }
}
