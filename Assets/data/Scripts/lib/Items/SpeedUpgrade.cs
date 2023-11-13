using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgradable {

    [SerializeField] float velMult = 1.2f;


    public override void updateStats(Hull hull, Engine engine) {
        engine.maxVel *= velMult;
    }






    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
