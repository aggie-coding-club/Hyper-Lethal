using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Steering : MonoBehaviour
{
    public float weight = 1;
    // This will be used to let steeringBehavior to select a set of steerings (dynamic ai)
    public AIStates AIState;
    
    protected GameObject target;

    public GameObject Target { get => target; set => target = value; }

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
