using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehavior : Steering
{
    [SerializeField]
    private Transform target;
    [SerializeField] private float targetRadius = 1.5f;
    [SerializeField] private float slowRadius = 5f;

    public override SteeringData GetSteering(SteeringBehaviorBase
    steeringbase)
    {
        SteeringData steering = new SteeringData();
        Vector2 direction = target.position - transform.position;
        float distance = direction.magnitude;

        // Try to stop while in target radius
        if (distance < targetRadius)
        {
            steering.linear = -steeringbase.GetComponent<Rigidbody2D>().velocity;
            return steering;
        }
        
        float targetSpeed;
        // Desired acceleration is reduced within the slow radius
        if (distance > slowRadius)
            targetSpeed = steeringbase.maxAcc;
        else
            targetSpeed = steeringbase.maxAcc * 
                (distance / slowRadius);

        // Sets the desired acceleration and reduces it based on current velocity.
        // I.e. It will approach the target velocity.
        Vector2 targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;
        steering.linear = targetVelocity - 
            steeringbase.GetComponent<Rigidbody2D>().velocity;

        // Reduces the magnitude and prevents this behavior
        // from overpowering other steering behaviors
        if (steering.linear.magnitude > steeringbase.maxAcc)
        {
            steering.linear.Normalize();
            steering.linear *= steeringbase.maxAcc;
        }
        steering.angular = 0;
        return steering;
    }
}
