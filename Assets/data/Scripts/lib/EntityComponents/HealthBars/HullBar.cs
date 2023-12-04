using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HullBar : MonoBehaviour
{
    Slider healthSlider;
    Hull hull;
    float maxHealth;
    float currentHealth;
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        hull = GetComponentInParent<Hull>();
        maxHealth = hull.MaxHull;
        currentHealth = maxHealth;
        healthSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = hull.HullHp;
        healthSlider.value = currentHealth / maxHealth;
    }
}