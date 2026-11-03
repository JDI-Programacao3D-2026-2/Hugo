using UnityEngine;
using UnityEngine.InputSystem;

public class SwordAttack : MonoBehaviour
{
    private float damage = 35f;
    public float rangeX = 0.26f;
    public float rangeY = 0.43f;
    public float rangeZ = 0.78f;

    public float attackCooldown = 1.2f;
    public LayerMask enemyLayer;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        Collider[] hits = Physics.OverlapBox(transform.position, new Vector3(rangeX, rangeY, rangeZ), Quaternion.identity, enemyLayer);

        foreach (Collider hit in hits)
        {
            EnemyHealth enemy = hit.GetComponentInParent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(rangeX, rangeY, rangeZ));
    }
}
