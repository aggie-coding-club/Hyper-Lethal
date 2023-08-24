using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 acceleration_real = Vector2.zero;
    private float angAcc_real = 0f;

    public float maxAcc = 20f;
    
    public float drag = 0.8f;

    public float maxVel = 40f;

    public float maxAngAcc = 720f;
    public float maxAngVel = 270f;
    public float angDrag = 3;

    public float rotation_input;

    public Vector2 impulse_vector;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 
        Vector2 acceleration_temp = impulse_vector;
        acceleration_real = Vector2.ClampMagnitude(acceleration_temp, maxAcc) - rb2D.velocity * drag;

        // 
        Vector2 velocity = rb2D.velocity + acceleration_real * Time.deltaTime;
        // Clamp it to max
        rb2D.velocity = Vector2.ClampMagnitude(velocity, maxVel);

        float angAcc_temp = -rotation_input;
        angAcc_real = Mathf.Clamp(angAcc_temp, -maxAngAcc, maxAngAcc) - rb2D.angularVelocity * angDrag;

        // Precalculate angular velocity
        float angVel = rb2D.angularVelocity + angAcc_real * Time.deltaTime;
        // Clamp it to max
        rb2D.angularVelocity = Mathf.Clamp(angVel, -maxAngVel, maxAngVel);

        if (Mathf.Abs(rb2D.rotation) > 180)
            rb2D.rotation += -Mathf.Sign(rb2D.rotation) *360;
    }
}