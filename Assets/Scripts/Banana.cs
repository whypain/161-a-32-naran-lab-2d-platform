using UnityEngine;

public class Banana : Weapon
{
    private float speed;

    private void Start()
    {
        speed = GetShootDirection() * 15;
    }

    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;

        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void OnHitWith(Character character)
    {
        throw new System.NotImplementedException();
    }
}
