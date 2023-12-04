using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    Slider healthSlider;
    Shield shield;
    float maxHealth;
    float currentHealth;
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        shield = GetComponentInParent<Shield>();
        maxHealth = shield.MaxShield;
        currentHealth = maxHealth;
        healthSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = shield.ShieldHp;
        healthSlider.value = currentHealth / maxHealth;
    }
}