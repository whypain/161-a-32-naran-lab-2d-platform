using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int Damage { get; set; }
    public IShootable Shooter;

    public abstract void Move();
    public abstract void OnHitWith(Character character);

    public void Init(int damage, IShootable shooter)
    {
        Damage = damage;
        Shooter = shooter;
    }

    public int GetShootDirection()
    {
        return Shooter.SpawnPoint.position.x - Shooter.SpawnPoint.parent.position.x > 0 ? 1 : -1;
    }

    public Vector3 GetShootDirection(Transform target)
    {
        return (target.position - Shooter.SpawnPoint.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
        {
            OnHitWith(character);
            Destroy(gameObject, 5f);
        }
    }
}
