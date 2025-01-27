using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static Action OnPowerUpCollected;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPowerUpCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
