using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private int health;
    public int Health { get => health; set => health = Mathf.Max(0, value); }

    protected Animator anim;
    protected Rigidbody2D rb;

    private float damageIFrame = 0.5f;
    private float tookDamageTimer = 0f;
    private bool isInvincible => tookDamageTimer > 0f;


    protected void Initialize(int startHealth)
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Health = startHealth;


        Debug.Log($"{name} initialized with {Health} health");  
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
        {
            Debug.Log($"{name}'s iframe is active and took no damage");
            return;
        }       

        Health -= damage;
        Debug.Log($"{name} took {damage} damage; currHealth: {Health}");

        tookDamageTimer = damageIFrame;

        IsDead();
    }
    
    private void Update()
    {
        if (tookDamageTimer > 0)
        {
            tookDamageTimer -= Time.deltaTime;
        }
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