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
                Projectile proj = collision.gameObject.GetComponent<Projectile>();
                gameObject.GetComponent<HealthManager>().damage(proj.damage);
                break;
        }
    }
}
