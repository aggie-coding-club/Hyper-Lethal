using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    Slider healthSlider;
    Shield shield;
    float maxHealth;
    float currentHealth;
    [SerializeField] GameObject followObject;
    [SerializeField] float yOffset = 1;
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
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(followObject.transform.position.x, followObject.transform.position.y + yOffset, 0);
        currentHealth = shield.ShieldHp;
        healthSlider.value = currentHealth / maxHealth;
    }
}