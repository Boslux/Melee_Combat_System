using UnityEngine;

public class EnemyAI3D : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Move")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stopDistance = 1.5f;

    [Header("Attack")]
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 1f;

    [Header("References")]
    [SerializeField] private EnemyHealth enemyHealth;

    private float lastAttackTime;

    private void Awake()
    {
        lastAttackTime = -attackCooldown;
    }

    private void Update()
    {
        if (target == null || enemyHealth == null)
            return;

        if (enemyHealth.GetState() != EntityState.Alive)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > stopDistance)
        {
            MoveToTarget();
            return;
        }

        TryAttack();
    }

    private void MoveToTarget()
    {
        Vector3 targetPosition = new Vector3(
            target.position.x,
            transform.position.y,
            target.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    private void TryAttack()
    {
        if (Time.time < lastAttackTime + attackCooldown)
            return;

        IDamageable damageable = target.GetComponent<IDamageable>();

        if (damageable == null)
            return;

        damageable.TakeDamage(new Damage(damage));
        lastAttackTime = Time.time;
    }
}