using System;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    public static Action<PlayerKiller> OnPlayerKilled;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerKilled?.Invoke(this);
        }
    }
}
