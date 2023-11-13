using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgradable : MonoBehaviour {
    // Start is called before the first frame update

    //pass by reference so is ok
    public abstract void updateStats(Hull hull, Engine engine);


    // void Start() {
        
    // }

    // // Update is called once per frame
    // void Update() {
        
    // }
}
