using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Slider healthSlider;
    Slider shieldSlider;
    [SerializeField] Transform healthBar;
    [SerializeField] Transform shieldBar;
    Shield playerShield;
    Hull playerHealth;
    float maxShield;
    float currentShield;
    float maxHealth;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider = healthBar.GetComponent<Slider>();
        shieldSlider = shieldBar.GetComponent<Slider>();
        playerShield = FindObjectOfType<PlayerController>().GetComponent<Shield>();
        playerHealth = FindObjectOfType<PlayerController>().GetComponent<Hull>();
        healthSlider.value = 0;
        shieldSlider.value = 0;
        maxShield = playerShield.MaxShield;
        maxHealth = playerHealth.MaxHull;
        currentHealth = maxHealth;
        currentShield = maxShield;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerHealth.HullHp;
        currentShield = playerShield.ShieldHp;
        healthSlider.value = currentHealth / maxHealth;
        shieldSlider.value = currentShield / maxShield;
    }
}
