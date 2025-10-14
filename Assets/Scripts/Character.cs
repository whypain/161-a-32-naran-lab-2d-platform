using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private int health;
    public int Health { get => health; set => health = Mathf.Max(0, value); }

    protected Animator anim;
    protected Rigidbody2D rb;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{name} took {damage} damage; currHealth: {Health}");
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{name} is dead and destroyed");
            return true;
        }

        return false;
    }
}