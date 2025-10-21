using UnityEngine;

public class Player : Character, IShootable
{
    private void Start()
    {
        Initialize(100);
    }

    public void Jump()
    {

    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            OnHitWith(enemy);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            OnHitWith(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Enemy enemy))
        {
            OnHitWith(enemy);
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Enemy enemy))
        {
            OnHitWith(enemy);
        }
    }

    public GameObject Bulllet { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Transform SpawnPoint { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float ReloadTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float WaitTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
