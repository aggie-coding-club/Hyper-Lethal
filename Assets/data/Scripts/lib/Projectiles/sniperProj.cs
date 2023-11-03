using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperProj : Projectile
{
    [SerializeField] int penetrateTimes = 1;
    [SerializeField] float penetrationMultipler = 0.8f;

    public int PenetrateTimes { get => penetrateTimes; set => penetrateTimes = value; }
    public float PenetrationMultipler { get => penetrationMultipler; set => penetrationMultipler = value; }

    public override void FixedUpdate()
    {
        updateProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<HealthManager>().damage(damage);
        updateDamage(penetrationMultipler);
        --penetrateTimes;

        if (penetrateTimes == 0)
        {
            Destroy(gameObject.GetComponentInParent<Transform>().gameObject);
            Destroy(gameObject);
            //print("delete bullet");
        }
        
    }
    private void updateDamage(float multiplier)
    {
        damage *= multiplier;
    }
}

