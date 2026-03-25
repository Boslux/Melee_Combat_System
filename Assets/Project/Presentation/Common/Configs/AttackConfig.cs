using UnityEngine;

[CreateAssetMenu(fileName = "AttackConfig", menuName = "Combat/Attack Config")]
public class AttackConfig : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; } = 20;
    [field: SerializeField] public float Range { get; private set; } = 1.5f;
    [field: SerializeField] public float Cooldown { get; private set; } = 1f;
    [field: SerializeField] public float KnockbackForce { get; private set; } = 3f;
    [field: SerializeField] public float HitStunDuration { get; private set; } = 0.15f;

    public AttackData ToAttackData()
    {
        return new AttackData(Damage, Range, Cooldown, KnockbackForce, HitStunDuration);
    }
}