using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCamera : MonoBehaviour
{
    public GameObject target;
    public float followDistance = 10;
    private Transform targetTransform; 
    

    // Start is called before the first frame update
    void Start()
    {
        targetTransform = target.GetComponent<Transform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 difference = transform.position - targetTransform.position;
        float magnitude = difference.magnitude;
        if (followDistance < magnitude)
            transform.position += Vector3.ClampMagnitude(difference, followDistance-magnitude);
    }
}
