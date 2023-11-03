using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class arcBomb : Weapon
{
    [SerializeField] private float spreadDeg = 15;
    private List<GameObject> bombs = new List<GameObject>();
    private projectileBehavior behavior;

    public override void shoot()
    {
        
        if (fireTimer < 0.1E-9)
        {
            fireTimer = fireDelay;
            
            for (int i = 0; i < pCount; ++i)
            {
                
                GameObject proj = Instantiate(projectile, firePoint.position, firePoint.rotation);
                //print(proj.gameObject);
                //projectile 1
                Transform trans = proj.GetComponent<Transform>();
                Rigidbody2D prb2D = proj.GetComponent<Rigidbody2D>();
                Projectile projData = proj.GetComponent<Projectile>();
                behavior = proj.GetComponentInChildren<projectileBehavior>();
                bombs.Add(proj);
                //projectile2
                //flips the sin wave movement based on projetile count
                behavior.determineSign(i);
                
                float offset = 0;
                if (pCount > 1)
                {
                    offset = Mathf.Lerp(-spreadDeg, spreadDeg, (i) / (float)(pCount - 1));
                }
                trans.Rotate(0, 0, offset + inaccuracy * UnityEngine.Random.Range(-180, 180));
                prb2D.velocity = trans.up * pVelocity;
                //Debug.Log(trans.up);
                trans.localScale *= pSize;

                projData.damage = damage;
                projData.pLifetime = pLifetime;

            }
            
            print(bombs.Count);
        }
    }
    public void disablePair(GameObject bomb)
    {
        bombs.Remove(bomb);
    }
    public List<GameObject> returnBombList()
    {
        return bombs;
    }
}
