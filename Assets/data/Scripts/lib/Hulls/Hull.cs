using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hull : MonoBehaviour
{
    [SerializeField] private float maxHull= 100;
    [SerializeField] private float regenRatePerc = 0.01f;
    
    // Will remove serialize field tag when optimizing
    [SerializeField] private float hullHp;
    [SerializeField] private bool broken = false;

    public float MaxHull { get => maxHull; set => maxHull = value; }
    public float RegenRatePerc { get => regenRatePerc; set => regenRatePerc = value; }
    public float HullHp { get => hullHp; set => hullHp = value; }
    public bool Broken { get => broken; set => broken = value; }

    // Start is called before the first frame update
    void Start()
    {
        hullHp = maxHull;   
    }

    public void updateHull()
    {
        if (broken)
            return;
        else if (hullHp < maxHull)
            hullHp += maxHull * regenRatePerc * Time.deltaTime;
        else
            hullHp = maxHull;
    }
    public bool damage(float damage)
    {
        hullHp -= damage;

        if (hullHp < 0.1E-9f)
        {
            hullHp = 0;
            broken = true;
        }
        return broken;
    }
    public abstract void FixedUpdate();
}
