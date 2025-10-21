using UnityEngine;

public class Croccodile : Enemy, IShootable
{
    public Player player;

    public GameObject Bulllet { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Transform SpawnPoint { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float ReloadTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float WaitTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


    private float attackRange;

    private void Start()
    {
        Initialize(50);
        DamageHit = 30;
        attackRange = 6f;

        player = FindFirstObjectByType<Player>();
    }


    private void FixedUpdate()
    {
        Behaviour();
    }

    public override void Behaviour()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(rb.position, player.transform.position);

        if (distanceToPlayer <= attackRange)
        {
            Debug.Log($"{player.name} is within attack range of {name}. Shooting!");
            Shoot();
        }
    }


    private void Shoot()
    {
        // Implement shooting logic here
        Debug.Log($"{name} shoots at {player.name}!");
    }
}
