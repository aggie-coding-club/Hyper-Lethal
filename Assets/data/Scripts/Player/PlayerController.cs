using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private controlScheme controller = controlScheme.Keyboard;
    [SerializeField] private Camera camera;
    private Rigidbody2D rb2d;   
    private Engine engine;
    private HealthManager healthManager;
    private Turret[] turrets;   

    private float rotationInput = 0;
    private Vector2 impulseVector = Vector2.zero;

    private enum controlScheme
    {
        Mouse,
        Keyboard
    };

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        engine = gameObject.GetComponent<Engine>();
        healthManager = gameObject.GetComponent<HealthManager>();
        turrets = gameObject.GetComponentsInChildren<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationInput = 0;
        impulseVector = Vector2.zero;

        switch (controller)
        {
            case controlScheme.Keyboard:
                if (Input.GetKey(KeyCode.LeftShift))
                    impulseVector = transform.up*engine.MaxAcc;
                if (Input.GetKey(KeyCode.RightArrow))
                    rotationInput += engine.MaxAngAcc;
                if (Input.GetKey(KeyCode.LeftArrow))
                    rotationInput -= engine.MaxAngAcc;
                if (Input.GetKey(KeyCode.Z))
                    foreach(Turret turret in turrets)
                        turret.shoot();
                break;
            case controlScheme.Mouse:
                if (Input.GetKey(KeyCode.Mouse0))
                    impulseVector = transform.up*engine.MaxAcc;
                if (Input.GetKey(KeyCode.Mouse1))
                    foreach(Turret turret in turrets)
                        turret.shoot();
                
                Vector2 diff = getMouseAbsolute() - rb2d.position;

                float delta = 90 - Mathf.Rad2Deg*Mathf.Atan2(diff.y,diff.x) + rb2d.rotation;
                
                if (Mathf.Abs(delta) > 180)
                    delta-=Mathf.Sign(delta)*360;
                
                // Linearly ramp to maximum angular velocity depending on the delta of rotation
                rotationInput = delta/180*engine.MaxAngAcc;

                // Start slowing the angular velocity
                if (Mathf.Abs(delta) < 90)
                    rotationInput += rb2d.angularVelocity;
                break;
            default:
                break;
        }

        engine.rotation_input = rotationInput;
        engine.impulse_vector = impulseVector;
    }
    Vector2 getMouseAbsolute()
    {
        Vector3 mouseRelative = Input.mousePosition;
        mouseRelative.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(mouseRelative);
    }
}
