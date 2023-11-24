using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : Upgradable {

    [SerializeField] float health;

    public override void updateStats(Hull hull, Engine engine) {
        hull.IncreaseHull(health);
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
