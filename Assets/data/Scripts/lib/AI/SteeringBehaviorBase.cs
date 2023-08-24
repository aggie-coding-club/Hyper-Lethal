using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour
{
    private Rigidbody2D rb;
    private Steering[] steerings;
    private Engine engine;
    
    public float maxAcc;
    public float maxAngAcc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        steerings = GetComponents<Steering>();
        engine = GetComponent<Engine>();

        maxAcc = engine.maxAcc;
        maxAngAcc = engine.maxAngAcc;
    }
    private void FixedUpdate()
    {
        Vector2 desiredAcc = Vector2.zero;
        float desiredRotation = 0f;
        foreach (Steering behavior in steerings)
        {
            SteeringData steering = behavior.GetSteering(this);
            desiredAcc += steering.linear;
            desiredRotation += steering.angular;
        }
        engine.impulse_vector = desiredAcc;
        engine.rotation_input = desiredRotation;
    }

    public Engine GetEngine()
    {
        return engine;
    }
}

