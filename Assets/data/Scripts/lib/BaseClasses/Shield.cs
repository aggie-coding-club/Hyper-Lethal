using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shield : MonoBehaviour
{
    [SerializeField] private float maxShield = 100;
    [SerializeField] private float rechargeRatePerc = 0.1f;
    [SerializeField] private float rechargeDelay = 2;
    [SerializeField] private float shutdownDelay = 6;

    // Will be converted into private variables during optimization,
    // this is just so I can view the states in real time without logging.
    [SerializeField] private float shieldHp;
    [SerializeField] private float rechargeTimer;
    [SerializeField] private float shutdownTimer;

    public float MaxShield { get => maxShield; set => maxShield = value; }
    public float RechargeRatePerc { get => rechargeRatePerc; set => rechargeRatePerc = value; }
    public float RechargeDelay { get => rechargeDelay; set => rechargeDelay = value; }
    public float ShutdownDelay { get => shutdownDelay; set => shutdownDelay = value; }
    public float ShieldHp { get => shieldHp; set => shieldHp = value; }
    public float RechargeTimer { get => rechargeTimer; set => rechargeTimer = value; }
    public float ShutdownTimer { get => shutdownTimer; set => shutdownTimer = value; }
    private enum States : short
    {
        normal = 0,
        shutdown = 1,
        recharging = 2,
    }
    private States state;

    // Start is called before the first frame update
    void Start()
    {
        state = States.normal;
        shieldHp = maxShield;
        
        rechargeTimer = rechargeDelay;
        shutdownTimer = shutdownDelay;
    }

    public void updateShield()
    {
        if (state == States.shutdown)
        { // Will stay in shutdown until shutdown timer expires
            shutdown();
        }
        else if (state == States.recharging)
        { // Recharge until damaged again or shieldHp is at max 
            recharge();
        }
    }

    private void recharge()
    {
        if (rechargeTimer > 0)
        {
            rechargeTimer -= Time.deltaTime;
        }
        else if (shieldHp < maxShield)
        {
            shieldHp += rechargeRatePerc * maxShield * Time.deltaTime;
        }
        else 
        {
            shieldHp = maxShield;
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

        shieldHp -= damage;
        
        if (shieldHp < 0.1E-9f)
        {
            overkill = -shieldHp;
            shieldHp = 0;
            state = States.shutdown;
        } else 
        {
            state = States.recharging;
            rechargeTimer = rechargeDelay;
        }
        return overkill;
    }
    public abstract void FixedUpdate();

}
