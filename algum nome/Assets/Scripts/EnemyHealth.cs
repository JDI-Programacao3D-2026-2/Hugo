using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    // Update is called once per frame
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
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
