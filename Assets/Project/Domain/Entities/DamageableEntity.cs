public class DamageableEntity : IDamageable, IHitReactable
{
    public Health Health { get; private set; }
    public EntityState State { get; private set; } = EntityState.Alive;

    private float hitTimer;

    public DamageableEntity(int maxHealth)
    {
        Health = new Health(maxHealth);
    }

    public void TakeDamage(Damage damage)
    {
        if (State == EntityState.Dead)
            return;

        Health.TakeDamage(damage.Value);

        if (Health.IsDead)
        {
            State = EntityState.Dead;
        }
    }

    public void OnHit(float duration)
    {
        if (State == EntityState.Dead)
            return;

        hitTimer = duration;
        State = EntityState.Hit;
    }

    public void Tick(float deltaTime)
    {
        if (State != EntityState.Hit)
            return;

        hitTimer -= deltaTime;

        if (hitTimer <= 0f)
        {
            hitTimer = 0f;

            if (!Health.IsDead)
                State = EntityState.Alive;
        }
    }
}