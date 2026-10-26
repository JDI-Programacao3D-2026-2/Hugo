using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;
    public Image healthBar;
    void Start()
    {
        Debug.Log("Max Health: " + maxHealth);
    }
    public void Health(float amount)
    {
        maxHealth = amount;
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        gameObject.SetActive(false);
        
    }
}
