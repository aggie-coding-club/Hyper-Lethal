using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penetratingSniper : Weapon
{
    [SerializeField] int pierceAmount = 2;
    [SerializeField] float pierceMultiplier = 0.8f;
    public override void shoot()
    {
        if (fireTimer < 0.1E-9)
        {
            fireTimer = fireDelay;
            for (int i = 0; i < pCount; ++i)
            {
                GameObject proj = Instantiate(projectile, firePoint.position, firePoint.rotation);
                Transform trans = proj.GetComponent<Transform>();
                Rigidbody2D prb2D = proj.GetComponent<Rigidbody2D>();
                sniperProj projData = proj.AddComponent<sniperProj>();

                trans.Rotate(0, 0, inaccuracy * Random.Range(-180, 180));
                prb2D.velocity = trans.up * pVelocity;
                trans.localScale *= pSize;

                projData.damage = damage;
                projData.pLifetime = pLifetime;
                projData.PenetrateTimes = pierceAmount;
                projData.PenetrationMultipler = pierceMultiplier;
            }

        }
    }
}

