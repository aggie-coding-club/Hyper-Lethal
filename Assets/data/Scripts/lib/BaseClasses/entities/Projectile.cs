using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Projectile : Entity
{
    public float damage;
    public float pLifetime;

    public void updateProjectile()
    {
        if (pLifetime > 0)
            pLifetime -= Time.deltaTime;
        else
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    public abstract void FixedUpdate();
}
