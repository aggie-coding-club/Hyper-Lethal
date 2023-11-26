using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] private bool suicide = false;
    private HealthManager healthManager;
    private Hull hull;
    void Start()
    {
        healthManager = gameObject.GetComponent<HealthManager>();
        hull = gameObject.GetComponent<Hull>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Projectile"):
                Projectile proj = collision.gameObject.GetComponent<Projectile>();
                healthManager.damage(proj.damage);
                break;
            
            default:
                collision.gameObject.GetComponent<HealthManager>().damage(hull.CollisionDamage);
                if (suicide)
                    Destroy(gameObject);
                break;
        }
    }
}