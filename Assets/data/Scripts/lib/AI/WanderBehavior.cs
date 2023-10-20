using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WanderBehavior : Steering
{

    [SerializeField] private float wanderRate = 0.4f;  
    [SerializeField] private float wanderOffset = 1.5f;  
    [SerializeField] private float wanderRadius = 4f; 
    private float wanderOrientation = 0f;
    private float RandomBinomial()
    {
        return Random.value - Random.value;
    }
    private Vector3 OrientationToVector(float orientation)
    {
        return new Vector3(Mathf.Cos(orientation),Mathf.Sin(orientation),0);
    }
    private float VectorToOrientation(Vector3 v)
    {
        return Mathf.Atan2(v.y,v.x);
    }
    public override SteeringData GetSteering(SteeringBehaviorBase steeringbase)
    {
        SteeringData steering = new SteeringData();

        wanderOrientation += RandomBinomial() * wanderRate;

        float objectOrientation = VectorToOrientation(GetComponent<Rigidbody2D>().velocity);

        float targetOrientation = objectOrientation + wanderOrientation;

        Vector3 targetPosition = transform.position + wanderOffset * OrientationToVector(objectOrientation);

        targetPosition += wanderRadius * OrientationToVector(targetOrientation);

        steering.linear = targetPosition - transform.position;
        steering.linear.Normalize();
        steering.linear *= steeringbase.maxAcc;
        steering.angular = 0;
        return steering;
    }
}
