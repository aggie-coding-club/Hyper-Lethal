using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SteeringBehaviorKami : SteeringBehaviorBase
{
    [SerializeField] private float searchPeriod = 2;
    [SerializeField] private float detectionRange  = 100;
    [SerializeField] private float trackingRange = 150;
    
    [SerializeField] private string targetLayer = "";
    private enum action
    {
        wandering = 0,
        attacking = 1
    };

    private action currentAction = action.wandering;
    private float searchTimer = 0;

    protected GameObject target = null;

    private void FixedUpdate()
    {
        // Since this is an expensive operation,
        // I do not want it running every frame
        if (searchTimer > searchPeriod)
        {
            searchTimer = 0;
            searchForTargets();
        }
        searchTimer += Time.deltaTime;

        Vector2 desiredAcc = Vector2.zero;
        float desiredRotation = 0f;
        foreach (Steering behavior in steerings )
        {
            if (behavior.category == ((int)currentAction))
            {
                behavior.Target = target;
                SteeringData steering = behavior.GetSteering(this);
                desiredAcc += steering.linear * behavior.weight;
                desiredRotation += steering.angular * behavior.weight;
            }
        }
        engine.impulse_vector = desiredAcc;
        engine.rotation_input = desiredRotation;

    }
    private void searchForTargets()
    {
        if (target)
        {
            currentAction = action.attacking;
            if ((transform.position-target.transform.position).magnitude < trackingRange)
                return;
            else
            {
                currentAction = action.wandering;
                target = null;
            }
        }

        LayerMask mask = LayerMask.GetMask(targetLayer);

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position,detectionRange,mask);
        
        float mindist = -1;
        
        foreach (Collider2D t in targets)
        {
            float magsqr = (transform.position-t.transform.position).sqrMagnitude;
            if (mindist < 0 || mindist > magsqr)
            {
                mindist = magsqr;
                target = t.gameObject;
            }
        }
    }
}

