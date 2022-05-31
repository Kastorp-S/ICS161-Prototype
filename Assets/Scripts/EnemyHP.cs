using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyHP : MonoBehaviour
{
    private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject healthBarUI;
    // Start is called before the first frame update
    void Start()
    {
        healthBarUI.SetActive(false);
        currentHealth = maxHealth;
        healthSlider.value = CalculateHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = CalculateHealth();

        if (currentHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            this.gameObject.GetComponent<EnemyAI>().dead = true;
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
    }
    void TakeDamage(float num)
    {
        currentHealth -= num;
        healthSlider.value = CalculateHealth();
    }
    float CalculateHealth()
    {
        return currentHealth/maxHealth;
    }
}
