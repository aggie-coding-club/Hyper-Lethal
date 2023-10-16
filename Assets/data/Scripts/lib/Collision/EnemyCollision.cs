using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
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
                if (collision.gameObject.GetComponent<Projectile>() != null)
                {
                    Projectile proj = collision.gameObject.GetComponent<Projectile>();
                    gameObject.GetComponent<HealthManager>().damage(proj.damage);
                }
                else if (collision.gameObject.GetComponentInParent<Projectile>() != null)
                {
                    Projectile proj = collision.gameObject.GetComponentInParent<Projectile>();
                    gameObject.GetComponent<HealthManager>().damage(proj.damage);
                }
                else
                {
                    projectileBehavior proj = collision.gameObject.GetComponent<projectileBehavior>();
                    gameObject.GetComponent<HealthManager>().damage(proj.returnExplodeDamage());
                }
                break;
        }
    }
}
