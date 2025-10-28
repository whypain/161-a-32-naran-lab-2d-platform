using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform SpawnPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }


    [SerializeField] private InputActionReference fireAction;


    private void Start()
    {
        Initialize(100);

        ReloadTime = 1f;
        WaitTime = 1f;
    }

    private void OnEnable()
    {
        fireAction.action.performed += Shoot;
    }

    private void OnDisable()
    {
        fireAction.action.performed -= Shoot;
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }


    private void Shoot(InputAction.CallbackContext _)
    {
        if (WaitTime < ReloadTime) return;
        
        WaitTime = 0;

        GameObject bullet = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
        Banana banana = bullet.GetComponent<Banana>();
        if (banana != null) 
        {
            banana.Init(20, this);
            Destroy(banana.gameObject, 5f);
        }
        
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
}
