using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable, IHitReactable, IKnockbackable
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private EnemyKnockback2D knockback2D;
    [SerializeField] private EnemyHitFeedback hitFeedback;

    private DamageableAdapter adapter;

    private void Awake()
    {
        adapter = new DamageableAdapter(maxHealth);

        if (knockback2D == null)
            knockback2D = GetComponent<EnemyKnockback2D>();

        if (hitFeedback == null)
            hitFeedback = GetComponent<EnemyHitFeedback>();
    }

    private void Update()
    {
        adapter.Tick(Time.deltaTime);
    }

    public void TakeDamage(Damage damage)
    {
        adapter.TakeDamage(damage.Value);
        hitFeedback?.PlayHitFeedback();

        Debug.Log($"HP: {adapter.GetCurrentHealth()} | State: {adapter.GetState()}");

        if (adapter.IsDead())
        {
            Die();
        }
    }

    public void OnHit(float duration)
    {
        adapter.ApplyHit(duration);
    }

    public void ApplyKnockback(float force)
    {
        if (knockback2D == null)
            return;

        knockback2D.ApplyKnockback(force);
    }

    public EntityState GetState()
    {
        return adapter.GetState();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}