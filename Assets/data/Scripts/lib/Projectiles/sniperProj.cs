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
<<<<<<< Updated upstream
        if (collision.tag == "Enemy")
        {
            penetrationDamage(penetrationMultipler);
            --penetrateTimes;
            //print("hit. Remaining:" + penetrateTimes);
        }
=======

        
        --penetrateTimes;

>>>>>>> Stashed changes
        if (penetrateTimes == 0)
        {
            Destroy(gameObject.GetComponentInParent<Transform>().gameObject);
            Destroy(gameObject);
            //print("delete bullet");
        }

    }
<<<<<<< Updated upstream
    private void penetrationDamage(float multiplier)
=======
    public void updateDamage()
>>>>>>> Stashed changes
    {
        damage *= penetrationMultipler;
    }
}

