using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyUIManager : MonoBehaviour
{
    Slider healthSlider;
    [SerializeField] Transform healthBar;
    [SerializeField] float yOffset;
    [SerializeField] GameObject enemy;
    Hull enemyHealth;
    float maxHealth;
    float currentHealth;
    void Start()
    {
        healthSlider = healthBar.GetComponentInChildren<Slider>();
        enemyHealth = GetComponentInParent<Hull>();
        maxHealth = enemyHealth.MaxHull;
        currentHealth = maxHealth;
        healthSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + yOffset, 0);
        currentHealth = enemyHealth.HullHp;
        healthSlider.value = currentHealth / maxHealth;
    }
}
