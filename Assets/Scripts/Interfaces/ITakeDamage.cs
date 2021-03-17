public interface ITakeDamage
{
    int Health { get; }
    bool IsDead { get; }
    void TakeDamage(int amount);
}