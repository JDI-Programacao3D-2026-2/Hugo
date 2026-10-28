using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;
    private float shield = 50;
    public Image healthBar;
    
    void Start()
    {
        UpdateHealthBar();
    }
    public void Health(float amount)
    {
        maxHealth = amount;
        currentHealth = maxHealth;
    }
    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        gameObject.SetActive(false);
        
    }
    public void RestoreHealth(float restore)
    {
        currentHealth = Mathf.Clamp(currentHealth + restore,0f, maxHealth);
        UpdateHealthBar();
        Debug.Log(currentHealth);
    }
    public void AddShield(float shieldValue)
    {
        
    }
}
