using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Hull playerHull = collision.gameObject.GetComponent<Hull>();
            Engine playerEngine = collision.gameObject.GetComponent<Engine>();
            if (playerHull != null && playerEngine != null) {
                if (gameObject.name == "Object1")
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
                Debug.Log("TAG: "+gameObject.tag);
                if(gameObject.tag == "Item") {
                    Debug.Log("BEFORE: "+playerEngine.maxVel);
                    gameObject.GetComponent<Upgradable>().updateStats(playerHull, playerEngine);
                    Destroy(gameObject);
                    Debug.Log("AFTER: "+playerEngine.maxVel);
                }
            }
        }
    }
}
