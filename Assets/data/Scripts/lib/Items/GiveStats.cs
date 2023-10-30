using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveStats : MonoBehaviour {

    [SerializeField] protected int healthScaleAdd = 10;
    [SerializeField] protected float speedScalemult = 1.1f;

    void doScale(Hull hull, Engine engine) {
        //scale the player parts
        hull.damage(-healthScaleAdd);//theres no public var or setter for hull
        engine.maxVel *= speedScalemult;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
