using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable, IHitReactable
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;

    [SerializeField] private PlayerHitFeedback hitFeedback;
    private DamageableAdapter adapter;

    private void Awake()
    {
        adapter = new DamageableAdapter(maxHealth);
    }
    public void TakeDamage(Damage damage)
    {
        adapter.TakeDamage(damage.Value);

        hitFeedback?.PlayFeedback();

        Debug.Log($"{gameObject.name} took {damage.Value} damage. Current HP: {adapter.GetCurrentHealth()}");

        if (adapter.IsDead())
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log($"{gameObject.name} died.");
    }

    public void OnHit(float duraction)
    {

    }
}