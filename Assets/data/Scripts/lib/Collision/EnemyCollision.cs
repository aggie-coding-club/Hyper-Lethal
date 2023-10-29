using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private bool suicide = false;
    [SerializeField] private float collisionDamage = 0;

    private HealthManager healthManager;
    void Start()
    {
        healthManager = gameObject.GetComponent<HealthManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Player"):
                collision.gameObject.GetComponent<HealthManager>().damage(collisionDamage);
                if (suicide)
                    Destroy(gameObject);
            break;
            case ("PlayerProjectile"):
                Projectile proj = collision.gameObject.GetComponent<Projectile>();
                healthManager.damage(proj.damage);
                break;
        }
    }
}
