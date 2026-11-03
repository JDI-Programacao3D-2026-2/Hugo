using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public CharacterStats PlayerStats;
    public CharacterStats myStats;
    private Minimap minimap;
    private EnemyNavMesh enemyNavMesh;

    public Transform respawnPoint;

    void Awake()
    {
        minimap = GetComponent<Minimap>();
        enemyNavMesh = GetComponent<EnemyNavMesh>();
    }
    void Start(){
        currentHealth = maxHealth;
    }
    public void TakeDamage(float amount){
        enemyNavMesh.ChangeState(EnemyNavMesh.EnemyState.Pursuit);
        if (minimap != null)
        {
            minimap.Reveal(3f);
        }
        currentHealth -= amount;
        if (currentHealth <= 0f)  {
            Die();
        }
    }
    void Die(){
        if (GameManager.ActiveStats != null)
        {
            GameManager.ActiveStats.AddKill();
        }
        myStats.AddDeath();
        gameObject.SetActive(false);
        transform.position = respawnPoint.position;
        Invoke("Respawn",3f);
        enemyNavMesh.ChangeState(EnemyNavMesh.EnemyState.WayPatrol);
        
    }
    void Respawn()
    {
        currentHealth = maxHealth;
        gameObject.SetActive(true);
    }
}

