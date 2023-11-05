using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float damage;
    public float pLifetime;
    arcBomb bombTracker;
    private void Start()
    {
        try
        {
            bombTracker = FindObjectOfType<arcBomb>().GetComponent<arcBomb>();
        }
        catch (System.NullReferenceException)
        {


        }
    }
    public void updateProjectile()
    {
        if (pLifetime > 0)
        {
            pLifetime -= Time.deltaTime;
        }
        else
        {
            if (bombTracker != null)
            {
                bombTracker.disablePair(gameObject);
            }
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
