using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Value;
    public static Action<Coin> OnCoinCollected;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCoinCollected?.Invoke(this);
            Debug.Log(GetComponent<Animator>().GetBool("IsCollected"));
            GetComponent<Animator>().SetBool("IsCollected", true);
            Debug.Log(GetComponent<Animator>().GetBool("IsCollected"));
            //Destroy(gameObject);
        }
    }
}
