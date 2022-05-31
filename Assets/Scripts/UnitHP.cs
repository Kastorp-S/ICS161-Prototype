using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHP : MonoBehaviour
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
    public void TakeDamage(float num)
    {
        currentHealth -= num;
        //Debug.Log("Unit " + this.gameObject.tag + " took " + num + " Damage");
        //Debug.Log("Current Health is: " + currentHealth);
        if (currentHealth <= 0)
        {
            if (this.gameObject.CompareTag("Player"))
            {
                //You died
            }
            else
            {
                this.gameObject.GetComponent<EnemyAI>().dead = true;
            }
        }
        healthSlider.value = CalculateHealth();
    }
    float CalculateHealth()
    {
        return currentHealth/maxHealth;
    }
}
