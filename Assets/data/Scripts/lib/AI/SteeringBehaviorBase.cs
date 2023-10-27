using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour
{
    private Rigidbody2D rb;
    private Steering[] steerings;
    private Engine engine;
    
    public float MaxAcc;
    public float MaxAngAcc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        steerings = GetComponents<Steering>();
        engine = GetComponent<Engine>();

        MaxAcc = engine.MaxAcc;
        MaxAngAcc = engine.MaxAngAcc;
    }
    private void FixedUpdate()
    {
        Vector2 desiredAcc = Vector2.zero;
        float desiredRotation = 0f;
        foreach (Steering behavior in steerings)
        {
            SteeringData steering = behavior.GetSteering(this);
            desiredAcc += steering.linear * behavior.weight;
            desiredRotation += steering.angular * behavior.weight;
        }
        engine.impulse_vector = desiredAcc;
        engine.rotation_input = desiredRotation;
    }

    public Engine GetEngine()
    {
        return engine;
    }
}

