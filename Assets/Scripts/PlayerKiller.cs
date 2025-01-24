using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKiller : MonoBehaviour
{
    public static Action<PlayerKiller> OnPlayerKilled;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerKilled?.Invoke(this);

            //SceneManager.LoadScene(2);

        }
    }
}
