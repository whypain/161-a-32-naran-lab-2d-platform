using UnityEngine;

public interface IShootable
{
    public GameObject Bulllet { get; set; }
    public Transform SpawnPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
}
