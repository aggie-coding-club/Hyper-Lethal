using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private Shield shield;
    private Hull hull;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        hull = gameObject.GetComponent<Hull>();
        shield = gameObject.GetComponent<Shield>();
    }

    public bool damage(float damage) 
    {
        dead = hull.damage((shield) ? shield.damage(damage) : damage);
        if (dead)
            Destroy(gameObject);
        return dead;
    }
}
