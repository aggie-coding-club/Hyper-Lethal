using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float damage;
    public float pLifetime;
    arcBomb bombTracker;
    private void Start()
    {
        bombTracker = FindObjectOfType<arcBomb>().GetComponent<arcBomb>();
    }

    public void updateProjectile()
    {
        if (pLifetime > 0)
        {
            pLifetime -= Time.deltaTime;
        }
        else
        {
            bombTracker.disablePair(gameObject);
            Destroy(gameObject);
        }
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        bombTracker.disablePair(gameObject);
        Destroy(gameObject.GetComponentInParent<Transform>().gameObject);
        Destroy(gameObject);

    }
    public abstract void FixedUpdate();
}
