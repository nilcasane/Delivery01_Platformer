using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int increase = 2;
    public static Action<int> OnPowerUpCollected;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPowerUpCollected?.Invoke(increase);
            Destroy(gameObject);
        }
    }
}
