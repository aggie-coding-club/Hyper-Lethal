using UnityEngine;

public class SteeringBehaviorGrunt : SteeringBehaviorBase
{
    [SerializeField] private float searchPeriod = 2;
    [SerializeField] private float detectionRange  = 40;
    [SerializeField] private float trackingRange = 60;
    [SerializeField] private string targetLayer = "";


    private AIStates currentAction = AIStates.wandering;
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
            if (behavior.AIState == currentAction)
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
            currentAction = AIStates.attacking;
            if ((transform.position-target.transform.position).magnitude < trackingRange)
                return;
            else
            {
                currentAction = AIStates.wandering;
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