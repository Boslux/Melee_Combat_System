public class AttackUseCase
{
    public void Execute(IDamageable target, AttackData attackData)
    {
        var damage = new Damage(attackData.Damage);
        target.TakeDamage(damage);

        if (target is IHitReactable hitReactable)
        {
            hitReactable.OnHit(attackData.HitStunDuration);
        }

        if (target is IKnockbackable knockbackable)
        {
            knockbackable.ApplyKnockback(attackData.KnockbackForce);
        }
    }
}