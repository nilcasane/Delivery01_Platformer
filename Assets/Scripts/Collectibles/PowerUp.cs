using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int time = 20;
    public int increase = 10;
    public static Action<PowerUp> OnPowerUpCollected;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPowerUpCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
