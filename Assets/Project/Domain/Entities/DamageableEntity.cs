public class DamageableEntity : IDamageable
{
    public Health Health { get; private set; }
    public DamageableEntity(int maxHelth)
    {
        Health = new Health(maxHelth);
    }
    public void TakeDamage(Damage damage)
    {
        Health.TakeDamage(damage.Value);
    }

}