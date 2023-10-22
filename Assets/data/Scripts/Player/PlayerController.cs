using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Engine engine;
    private HealthManager healthManager;
    private Turret[] turrets;   
    // Start is called before the first frame update
    void Start()
    {
        engine = gameObject.GetComponent<Engine>();
        healthManager = gameObject.GetComponent<HealthManager>();
        turrets = gameObject.GetComponentsInChildren<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        engine.rotation_input = Input.GetAxisRaw("Horizontal")* engine.maxAngAcc;
        engine.impulse_vector = transform.up*Input.GetAxisRaw("Vertical")*engine.maxAcc;
        if (Input.GetKey(KeyCode.Q))
        {
            foreach(Turret turret in turrets)
            {
                turret.shoot();
            }
        }
    }
}
