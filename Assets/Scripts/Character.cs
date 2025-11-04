using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int Health { get => health; set => health = Mathf.Clamp(Mathf.Max(0, value), 0, MaxHealth); }
    public int MaxHealth { get => maxHealth; set => maxHealth = Mathf.Max(1, value); }
    public float Health01 => (float)Health / (float)MaxHealth;
    public Action<float> onHealthChanged;
    public Action onDeath;

    protected Animator anim;
    protected Rigidbody2D rb;


    [SerializeField] CharacterHealthbar healthbarPrefab;
    [SerializeField] Transform healthbarParent;
    [SerializeField] Vector3 healthbarOffset;
    [SerializeField] bool persistentHealthbar;
    private int health;
    private int maxHealth;
    private float damageIFrame = 0.5f;
    private float tookDamageTimer = 0f;
    private bool isInvincible => tookDamageTimer > 0f;


    protected void Initialize(int startHealth)
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        MaxHealth = startHealth;
        Health = MaxHealth;

        if (healthbarPrefab != null)
        {
            CharacterHealthbar healthbar = Instantiate(healthbarPrefab, healthbarParent);
            healthbar.Initialize(this, persistentHealthbar);
            healthbar.transform.localPosition = healthbarOffset;
        }
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
        onHealthChanged?.Invoke(Health01);
        Debug.Log($"{name} took {damage} damage; currHealth: {Health}");

        tookDamageTimer = damageIFrame;

        if (IsDead()) onDeath?.Invoke();
    }
    
    protected virtual void Update()
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