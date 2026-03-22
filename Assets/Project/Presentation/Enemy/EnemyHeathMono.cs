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

        Debug.Log($"Enemy Health: {adapter.GetCurrentHealth()}");

        if (adapter.IsDead())
        {
            Debug.Log("Enemy Died");
            Destroy(gameObject);
        }
    }
}