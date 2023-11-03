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
            switch (gameObject.name)
            {
                case ("Kami"):
                    Destroy(gameObject);
                    break;
            }
            break;
            case ("PlayerProjectile"):
                Projectile proj = collision.gameObject.GetComponent<Projectile>();
                gameObject.GetComponent<HealthManager>().damage(proj.damage);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("PlayerProjectile"):
                Projectile proj = collision.gameObject.GetComponent<Projectile>();
                gameObject.GetComponent<HealthManager>().damage(proj.damage);
                //print(proj.damage);
                break;
        }
    }
}
