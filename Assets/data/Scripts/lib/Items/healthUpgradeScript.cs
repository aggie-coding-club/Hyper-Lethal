using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Old code, pls use new one
public class healthUpgradeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with player detected");

            Hull playerHull = collision.gameObject.GetComponent<Hull>();
            if (playerHull != null)
            {
                if (gameObject.name == "healthUpgrade")
                {
                    // Increase the player's hull by 10
                    playerHull.IncreaseHull(10);
                    float updatedHull = playerHull.getHull();
                    Debug.Log("Player's hull is now: " + updatedHull);

                    // Destroy the item
                    Destroy(gameObject);

                    // Log that the item was destroyed
                    UnityEngine.Debug.Log("Item was destroyed");
                }
            }
        }
    }
}

