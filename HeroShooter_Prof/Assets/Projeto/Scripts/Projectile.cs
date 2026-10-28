using UnityEngine; // Importa as funções da Unity.

public class Projectile : MonoBehaviour
{
    private float speed = 100f; 
    private float damageToPlayer = 23f;
    private float damageNoob = 21;
    private float damageVigi = 34;

    private float damage;
    private Vector3 direction; 
    private ShootPool Shootpool;

    void Awake()
    {
        switch (GameManager.ChoosenCharacterIndex)
        {
            case 0:
                damage = damageNoob;
                break;
            case 1:
                damage = damageVigi; 
                break;
        }

    }
    void OnEnable()
    {
        Invoke("SpawnTime", 5f); 
    }

    public void StartProjectile(Vector3 direction, ShootPool shooter)
    {
        this.direction = direction; 
        this.Shootpool = shooter;        
    }
    void Update()
    {       
        transform.position += direction * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {     
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
        if (player != null) {
            player.TakeDamage(damageToPlayer);
        }
        CancelInvoke("SpawnTime");
        Shootpool.ReturnProjectile(gameObject);
    }
    void SpawnTime()
    {
         Shootpool.ReturnProjectile(gameObject);
    }
}