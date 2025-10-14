using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int Damage { get; set; }
    public IShootable Shooter;

    public abstract void Move();
    public abstract void OnHitWith(Character character);
    public int GetShootDirection()
    {
        return 0;
    }
}
