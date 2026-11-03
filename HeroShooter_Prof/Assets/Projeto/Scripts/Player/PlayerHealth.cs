using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    private float shield = 0; 
    private float maxShield;
    public Image healthBar;
    public Image shieldBar;

    public bool isBlocking = false;
    public Transform respawnPoint;
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
    void UpdateShieldBar()
    {
        if (shieldBar == null) return;
        shieldBar.gameObject.SetActive(shield > 0);
        if (maxShield > 0)
        {
            shieldBar.fillAmount = shield / maxShield;
        }
        
    }
    public void TakeDamage(float damage)
    {
        if (isBlocking)
        {
            return;
        }
        if (shield > 0)
        {
            float absorbed = Mathf.Min(shield, damage);
            shield -= absorbed;
            damage -= absorbed;
            UpdateShieldBar();
        }

        if (damage <= 0) return;

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
        Invoke("Respawn", 3f);
    }
    public void RestoreHealth(float restore)
    {
        currentHealth = Mathf.Clamp(currentHealth + restore,0f, maxHealth);
        UpdateHealthBar();
        Debug.Log(currentHealth);
    }
    public void AddShield(float shieldValue, float duration)
    {
        StartCoroutine(ShieldTimer(shieldValue, duration));
    }
    IEnumerator ShieldTimer(float shieldValue, float duration)
    {
        shield = shieldValue;
        maxShield = shieldValue;
        UpdateShieldBar();

        yield return new WaitForSeconds(duration);

        shield = 0;
        UpdateShieldBar();
    }
    void Respawn()
    {
        transform.position = respawnPoint.position;
        currentHealth = maxHealth;
        UpdateHealthBar();
        gameObject.SetActive(true);
    }
}
