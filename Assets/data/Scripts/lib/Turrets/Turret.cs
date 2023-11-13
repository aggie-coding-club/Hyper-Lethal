using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private bool coaxial =  true;
    [SerializeField] private bool autonomous = false;
    [SerializeField] private string targetLayer = "";
    [SerializeField] private float searchPeriod = 2;
    private Weapon turretWeapon;
    private float range = 0;
    private GameObject target;
    private float searchTimer = 0;

    public bool Coaxial { get => coaxial; set => coaxial = value; }
    public bool Autonomous { get => autonomous; set => autonomous = value; }
    public Weapon TurretWeapon { get => turretWeapon; set => turretWeapon = value; }
    public String Mask { get => targetLayer; set => targetLayer = value; }

    // Start is called before the first frame update
    void Start()
    {
        turretWeapon = GetComponent<Weapon>();
        range = turretWeapon.PVelocity * turretWeapon.PLifetime;
    }
    // If Coaxial, turret remains in a fixed position, will auto fire if autonomous is set.
    // Otherwise, turret will be manually controlled by player/AI or it will select its own targets.
    private void FixedUpdate()
    {
        if (autonomous)
        {
            // Since this is an expensive operation,
            // I do not want it running every frame
            if (searchTimer > searchPeriod)
            {
                searchTimer = 0;
                searchForTargets();
            }
            searchTimer += Time.deltaTime;
            // Get the rigid body of the target
            // If coaxial do raycast, if hit, shoot
            if (coaxial)
            {

            }
            else if (target)
            {
                Vector2 delta = target.transform.position - transform.position;
                float angle = -90 + Mathf.Rad2Deg*Mathf.Atan2(delta.y, delta.x) - transform.eulerAngles.z;

                if (Mathf.Abs(angle) > 180)
                    angle-=Mathf.Sign(angle)*360;
                
                Debug.Log(target.name);
                transform.Rotate(new Vector3(0, 0,angle),Space.World);
            }
            
        }
        else
        {
            // Manual targeting...
        }
    }
    private void searchForTargets()
    {
        LayerMask mask = LayerMask.GetMask(targetLayer);

        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position,range,mask);
        
        float mindist = -1;
        
        foreach (Collider2D t in targets)
        {
            float magsqr = (transform.position-t.transform.position).sqrMagnitude;
            if (mindist < 0 || mindist > magsqr)
            {
                mindist = magsqr;
                target = t.gameObject;
            }
        }
        
        if (target)
            Debug.Log("Hit!");
    }
    public void shoot()
    {
        turretWeapon.shoot();
    }
}
