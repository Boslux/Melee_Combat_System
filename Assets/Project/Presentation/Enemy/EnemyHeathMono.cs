using UnityEngine;

public class EnemyHealthMono : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 100;

    private DamageableAdapter adapter;

    private void Awake()
    {
        adapter = new DamageableAdapter(maxHealth);
    }

    public void TakeDamage(Damage damage)
    {
        adapter.TakeDamage(damage.Value);

        Debug.Log($"{gameObject.name} took {damage.Value} damage. Current HP: {adapter.GetCurrentHealth()}");

        if (adapter.IsDead())
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }
}