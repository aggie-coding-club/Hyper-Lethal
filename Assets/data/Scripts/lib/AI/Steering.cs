using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Steering : MonoBehaviour
{
    public abstract SteeringData GetSteering(SteeringBehaviorBase steeringbase);
}

public class SteeringData
{
    public Vector2 linear;
    public float angular;
    public SteeringData()
    {
        linear = Vector2.zero;
        angular = 0f;
    }
}
