
public class Health
{
    public int Current { get; private set; }
    public int Max { get; private set; }

    public bool IsDead => Current < 0;

    public Health(int max)
    {
        Max = max;
        Current = max;
    }
    public void TakeDamage(int damage)
    {
        Current -= damage;

        if (Current < 0)
            Current = 0;
    }
}