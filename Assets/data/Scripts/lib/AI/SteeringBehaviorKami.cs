using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SteeringBehaviorKami : SteeringBehaviorBase
{
    [SerializeField] private float searchPeriod = 2;
    [SerializeField] private float detectionRange  = 100;
    [SerializeField] private float trackingRange = 150;

    [SerializeField] private const int wanderingCategory = 0;
    [SerializeField] private const int idlingCategory = 1;
    [SerializeField] private const int attackingCategory = 2;
    private enum action
    {
        wandering = wanderingCategory,
        idling = idlingCategory,
        attacking = attackingCategory
    };

    private action currentMode = action.wandering;
    private float searchTimer = 0;

    private void FixedUpdate()
    {
        Vector2 desiredAcc = Vector2.zero;
        float desiredRotation = 0f;
        foreach (Steering behavior in steerings )
        {
            SteeringData steering = behavior.GetSteering(this);
            desiredAcc += steering.linear * behavior.weight;
            desiredRotation += steering.angular * behavior.weight;
        }
        engine.impulse_vector = desiredAcc;
        engine.rotation_input = desiredRotation;
    }

    public new Engine GetEngine()
    {
        return engine;
    }
}

