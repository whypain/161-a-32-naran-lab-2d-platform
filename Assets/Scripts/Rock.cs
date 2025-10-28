using UnityEngine;

public class Rock : Weapon
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 force;

    private void Start()
    {
        force = new Vector2(GetShootDirection() * 90, 500);
    }

    public void SetForce(Vector2 newForce)
    {
        force = newForce;
    }

    public override void Move()
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player player)
        {
            player.TakeDamage(Damage);
        }
    }
}
