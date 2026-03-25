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

    public void ApplyHit(float duration)
    {
        entity.OnHit(duration);
    }

    public void Tick(float deltaTime)
    {
        entity.Tick(deltaTime);
    }

    public EntityState GetState()
    {
        return entity.State;
    }

    public int GetCurrentHealth()
    {
        return entity.Health.Current;
    }

    public bool IsDead()
    {
        return entity.State == EntityState.Dead;
    }
}