public class DamageableAdapter
{
    private readonly DamageableEntity entity;

    public DamageableAdapter(int maxHealth)
    {
        entity = new DamageableEntity(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        entity.TakeDamage(new Damage(damage));
    }

    public int GetCurrentHealth()
    {
        return entity.Health.Current;
    }

    public bool IsDead()
    {
        return entity.Health.IsDead;
    }
}