using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull : MonoBehaviour
{
    [SerializeField] private float maxHull= 100;
    [SerializeField] private float regenRatePerc = 0.01f;
    
    // Will remove serialize field tag when optimizing
    [SerializeField] private float hull;
    [SerializeField] private bool broken = false;

    // Start is called before the first frame update
    void Start()
    {
        hull = maxHull;   
    }

    void FixedUpdate()
    {
        if (broken)
            return;
        else if (hull < maxHull)
            hull += maxHull * regenRatePerc * Time.deltaTime;
        else
            hull = maxHull;
    }
    public bool damage(float damage)
    {
        hull -= damage;

        if (hull < 0.1E-9f)
        {
            hull = 0;
            broken = true;
        }
        return broken;
    }
}
