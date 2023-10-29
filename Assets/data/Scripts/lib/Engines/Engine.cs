using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Engine : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private Vector2 acceleration_real = Vector2.zero;
    private float angAcc_real = 0f;

    [SerializeField] private float maxAcc = 20f;
    [SerializeField] private float maxVel = 40f;
    [SerializeField] private float drag = 0.8f;


    [SerializeField] private float maxAngAcc = 720f;
    [SerializeField] private float maxAngVel = 270f;
    [SerializeField] private float angDrag = 3;

    public float rotation_input;

    public Vector2 impulse_vector;

    public Vector2 Acceleration_real { get => acceleration_real; set => acceleration_real = value; }
    public float AngAcc_real { get => angAcc_real; set => angAcc_real = value; }
    public float MaxAcc { get => maxAcc; set => maxAcc = value; }
    public float Drag { get => drag; set => drag = value; }
    public float MaxVel { get => maxVel; set => maxVel = value; }
    public float MaxAngAcc { get => maxAngAcc; set => maxAngAcc = value; }
    public float MaxAngVel { get => maxAngVel; set => maxAngVel = value; }
    public float AngDrag { get => angDrag; set => angDrag = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public void updateMovement()
    {
        // 
        Vector2 acceleration_temp = impulse_vector;
        acceleration_real = Vector2.ClampMagnitude(acceleration_temp, maxAcc) ;

        // 
        Vector2 velocity = rb2D.velocity + (acceleration_real - rb2D.velocity * drag) * Time.deltaTime;
        // Clamp it to max
        rb2D.velocity = Vector2.ClampMagnitude(velocity, maxVel);

        float angAcc_temp = -rotation_input;
        angAcc_real = Mathf.Clamp(angAcc_temp, -maxAngAcc, maxAngAcc);

        ;

        // Precalculate angular velocity
        // I made drag depend on the distance bewteen the angular velocity and the extrema.
        float angVel = rb2D.angularVelocity + (angAcc_real - (rb2D.angularVelocity-MathF.Sign(angAcc_real)*maxAngVel) * angDrag) * Time.deltaTime;
        
        // Clamp it to max
        rb2D.angularVelocity = Mathf.Clamp(angVel, -maxAngVel, maxAngVel);

        if (Mathf.Abs(rb2D.rotation) > 180)
            rb2D.rotation += -Mathf.Sign(rb2D.rotation) *360;
    }
    public abstract void FixedUpdate();
}