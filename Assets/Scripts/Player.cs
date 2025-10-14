using UnityEngine;

public class Player : Character, IShootable
{
    public void Jump()
    {

    }

    public void OnHitWith(Enemy enemy)
    {

    }

    public GameObject Bulllet { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Transform SpawnPoint { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float ReloadTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float WaitTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
