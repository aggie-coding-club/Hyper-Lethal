using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arcBomb : Weapon
{
    [SerializeField] private float spreadDeg = 15;
    Rigidbody2D theProjectileRb;
    Transform theProjectileTrans;
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
                Projectile projData = proj.GetComponent<Projectile>();
                theProjectileRb = prb2D;
                theProjectileTrans = trans;
                float offset = 0;
                if (pCount > 1)
                    offset = Mathf.Lerp(-spreadDeg, spreadDeg, (i) / (float)(pCount - 1));
                trans.Rotate(0, 0, offset + inaccuracy * UnityEngine.Random.Range(-180, 180));
                prb2D.velocity = trans.up * pVelocity;
                Debug.Log(trans.up);
                trans.localScale *= pSize;

                projData.damage = damage;
                projData.pLifetime = pLifetime;


            }

        }
    }
}
