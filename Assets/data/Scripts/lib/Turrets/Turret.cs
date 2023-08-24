using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    public void shoot()
    {
        weapon.shoot();
    }
}
