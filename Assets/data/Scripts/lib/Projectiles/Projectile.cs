using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
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
        HealthManager hm = collision.gameObject.GetComponent<HealthManager>();
        if (hm) hm.damage(damage);
        
        Destroy(gameObject);
    }
    public abstract void FixedUpdate();
}
