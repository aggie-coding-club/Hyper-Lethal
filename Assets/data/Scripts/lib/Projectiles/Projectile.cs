using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float pLifetime;

    private void FixedUpdate()
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
}
