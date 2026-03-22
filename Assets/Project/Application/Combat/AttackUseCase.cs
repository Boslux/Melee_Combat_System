public class AttackUseCase
{
    public void Execute(IDamageable target, AttackData attackData)
    {
        var damage = new Damage(attackData.Damage);
        target.TakeDamage(damage);
    }
}