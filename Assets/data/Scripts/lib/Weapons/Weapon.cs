using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;

    [SerializeField] protected float damage = 10;
    [SerializeField] protected float fireRate = 1;
    [SerializeField] protected float pVelocity = 50;
    [SerializeField] protected float pLifetime = 10;
    [SerializeField] protected float pSize = 1;

    [SerializeField] protected int  pCount = 3;
    [SerializeField] protected float accuracy  = 1;

    [SerializeField] protected float fireTimer;

    protected float fireDelay;
    protected float inaccuracy;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = 0;
        fireDelay = 1 / fireRate;
        inaccuracy = (1 - accuracy);
    }

    private void FixedUpdate()
    {
        if (fireTimer > 0)
            fireTimer -= Time.deltaTime;
    }
    public abstract void shoot();

}
