using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperProj : Projectile
{
    [SerializeField] int penetrateTimes = 1;
    [SerializeField] float penetrationMultipler = 0.8f;
    public override void FixedUpdate()
    {
        updateProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        --penetrateTimes;
        if (penetrateTimes == 0)
        {
            Destroy(gameObject.GetComponentInParent<Transform>().gameObject);
            Destroy(gameObject);
            //print("delete bullet");
        }

    }

    public void updateDamage()
    {
        damage *= penetrationMultipler;
    }
}

