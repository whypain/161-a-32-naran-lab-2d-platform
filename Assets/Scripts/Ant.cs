using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private LayerMask point;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float flipCooldown = 1f;

    private Vector2 velocity;


    private void Start()
    {
        Initialize(10);
        DamageHit = 20;
        velocity = new Vector2(-1 * moveSpeed, 0);
    }

    public override void Behaviour()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (velocity.x < 0 && rb.position.x <= movePoints[0].position.x)
        {
            Flip();   
        }
        else if (velocity.x > 0 && rb.position.x >= movePoints[1].position.x)
        {
            Flip();
        }
    }

    private void Flip()
    {
        velocity.x *= -1;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        Behaviour();
    }
    
}
