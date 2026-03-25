
using UnityEngine;

public class EnemyAI2D : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Move")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stopDistance = 1.2f;

    [Header("Attack")]
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 1f;

    [Header("Referance")]
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Rigidbody2D rb;

    private float lastAttackTimer;

    private void Awake()
    {
        lastAttackTimer = -attackCooldown;
    }
    private void FixedUpdate()
    {
        if (target == null || enemyHealth == null || rb == null)
            return;

        if (enemyHealth.GetState() != EntityState.Alive)
            return;
        MoveToTarget();
    }
    private void MoveToTarget()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance <= stopDistance)
        {
            TryAttack();
        }
        else
        {
            Vector2 direction = (target.position - transform.position).normalized;
            Vector2 next = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(next);
        }
    }
    private void TryAttack()
    {
        Debug.Log("1");
        if (Time.time < lastAttackTimer + attackCooldown) return;

        IDamageable damageable = target.GetComponent<IDamageable>();
        Debug.Log("2");
        if (damageable == null) return;

        Debug.Log("3");
        damageable.TakeDamage(new Damage(damage));
        lastAttackTimer = Time.time;
    }
}