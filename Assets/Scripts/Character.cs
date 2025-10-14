using UnityEngine;

public abstract class Character
{
    public int Health { get; set; }

    protected Animator anim;
    protected Rigidbody2D rb;

    public void TakeDamage(int damage)
    {

    }

    public bool IsDead() => Health <= 0;
}