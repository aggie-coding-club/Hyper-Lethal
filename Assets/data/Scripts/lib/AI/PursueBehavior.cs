using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueBehavior : Steering
{
    [SerializeField] private GameObject target;
    [SerializeField] private float prediction;
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();

        // I want to predict where the target is going to be
        Vector2 prediction_delta_target = target.GetComponent<Rigidbody2D>().velocity * prediction;
        Vector2 predicted_location_target = (Vector2) target.transform.position + prediction_delta_target;

        // And I want to predict where I am going to be
        Vector2 prediction_delta_self = GetComponent<Rigidbody2D>().velocity * prediction;
        Vector2 predicted_location_self = (Vector2) transform.position + prediction_delta_self;

        // The delta between where I think I'm going to be and where I think my target will be is where I should be going
        steering.linear = predicted_location_target - predicted_location_self;
        
        steering.linear.Normalize();
        steering.linear *= steeringbase.maxAcc;
        steering.angular = 0;
        return steering;
    }
}
