public abstract class Enemy : Character
{
    public int DamageHit { get; set; }
    public abstract void Behaviour();
}
