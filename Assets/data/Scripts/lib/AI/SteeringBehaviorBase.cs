using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Steering[] steerings;
    

    public float MaxAcc;
    public float MaxAngAcc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        steerings = GetComponents<Steering>();
    }
}