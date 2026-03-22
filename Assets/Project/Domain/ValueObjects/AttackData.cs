using System.Data;

public struct AttackData
{
    public int Damage;
    public float Range;
    public AttackData(int damage, float range)
    {
        Damage = damage;
        Range = range;
    }
}