using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Croccodile : Enemy, IShootable
{
    public Player player;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform SpawnPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }


    private float attackRange;
    private Vector3 dirToPlayer;


    private void Start()
    {
        Initialize(50);
        DamageHit = 30;
        attackRange = 6f;

        WaitTime = 1;
        ReloadTime = 1;

        player = FindFirstObjectByType<Player>();
    }

    protected override void Update()
    {
        base.Update();
        if (player == null) return;

        dirToPlayer = transform.position - player.transform.position;
        Debug.Log($"Direction: {dirToPlayer}");
        dirToPlayer = dirToPlayer.normalized;
    }


    private void FixedUpdate()
    {
        Behaviour();

        WaitTime += Time.fixedDeltaTime;
    }

    public override void Behaviour()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(rb.position, player.transform.position);

        if (distanceToPlayer <= attackRange)
        {
            Shoot();
        }
    }

    
    private void Shoot()
    {
        if (WaitTime < ReloadTime) return;
        WaitTime = 0;

        PlayAnim();

        GameObject bullet = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
        Rock rock = bullet.GetComponent<Rock>();

        rock.Init(40, this);

        rock.SetForce(9 * rock.GetShootDirection(player.transform));
        rock.Move();

        Destroy(bullet, 5f);

        Debug.Log($"{name} shoots at {player.name}!");
    }

    async void PlayAnim()
    {
        anim.SetTrigger("Shoot");
        await Task.Delay(100);
        anim.ResetTrigger("Shoot");
    }
}
