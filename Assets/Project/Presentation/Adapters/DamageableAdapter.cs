using System.Data;
using System.Xml.Serialization;

public class DamageableAdapter
{
    private readonly DamageableEntity entity;
    public DamageableAdapter(int maxHelth)
    {
        entity = new DamageableEntity(maxHelth);
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