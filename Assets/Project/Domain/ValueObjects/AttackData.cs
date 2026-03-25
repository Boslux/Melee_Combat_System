using System.Data;

public struct AttackData
{
    public int Damage { get; }
    public float Range { get; }
    public float Cooldown { get; }
    public float KnockbackForce { get; }
    public float HitStunDuration { get; }
    public AttackData(int damage, float range, float cooldown, float knockbackForce, float hitStunDuration)
    {
        Damage = damage;
        Range = range;
        Cooldown = cooldown;
        KnockbackForce = knockbackForce;
        HitStunDuration = hitStunDuration;
    }
}