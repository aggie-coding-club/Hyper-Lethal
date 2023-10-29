using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    [SerializeField] private float spreadDeg = 15;
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
                BlasterProj projData = proj.GetComponent<BlasterProj>();

                float offset = 0;
                if (pCount > 1)
                    offset = Mathf.Lerp(-spreadDeg, spreadDeg, (i) / (float)(pCount - 1));
                trans.Rotate(0, 0, offset + inaccuracy * Random.Range(-180, 180));
                prb2D.velocity = trans.up * pVelocity;
                trans.localScale *= pSize;

                projData.damage = damage;
                projData.pLifetime = pLifetime;


            }

        }
    }
}
