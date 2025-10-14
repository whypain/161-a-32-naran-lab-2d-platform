using UnityEngine;

public class Croccodile : Enemy, IShootable
{
    private float attackRange;
    public Player player;

    public GameObject Bulllet { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Transform SpawnPoint { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float ReloadTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float WaitTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override void Behaviour()
    {
        throw new System.NotImplementedException();
    }
}
