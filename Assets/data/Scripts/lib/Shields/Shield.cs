using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    [SerializeField] private float maxShield = 100;
    [SerializeField] private float rechargeRatePerc = 0.1f;
    [SerializeField] private float rechargeDelay = 2;
    [SerializeField] private float shutdownDelay = 6;

    
    private enum States : short
    {
        normal = 0,
        shutdown = 1,
        recharging = 2,
    }
    private States state;

    // Will be converted into private variables during optimization,
    // this is just so I can view the states in real time without logging.
    [SerializeField] private float shield;
    [SerializeField] private float rechargeTimer;
    [SerializeField] private float shutdownTimer;

    // Start is called before the first frame update
    void Start()
    {
        state = States.normal;
        shield = maxShield;
        
        rechargeTimer = rechargeDelay;
        shutdownTimer = shutdownDelay;
    }

    private void FixedUpdate()
    {

        if (state == States.shutdown)
        { // Will stay in shutdown until shutdown timer expires
            shutdown();
        }
        else if (state == States.recharging)
        { // Recharge until damaged again or shield is at max 
            recharge();
        }
    }

    private void recharge()
    {
        if (rechargeTimer > 0)
        {
            rechargeTimer -= Time.deltaTime;
        }
        else if (shield < maxShield)
        {
            shield += rechargeRatePerc * maxShield * Time.deltaTime;
        }
        else 
        {
            shield = maxShield;
            state = States.normal;
            rechargeTimer = rechargeDelay;
        }
        
    }
    private void shutdown()
    {
        if (shutdownTimer > 0)
        {
            shutdownTimer -= Time.deltaTime;
        }
        else
        {
            state = States.recharging;
            rechargeTimer = 0;
            shutdownTimer = shutdownDelay;
        }
    }
    public float damage(float damage) 
    {
        float overkill = 0;

        shield -= damage;
        
        if (shield < 0.1E-9f)
        {
            overkill = -shield;
            shield = 0;
            state = States.shutdown;
        } else 
        {
            state = States.recharging;
            rechargeTimer = rechargeDelay;
        }
        return overkill;
    }
}
