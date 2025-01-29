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
            GetComponent<Animator>().SetBool("IsCollected", true);
            float moveAnimationTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
            Invoke("DestroyCoin", moveAnimationTime);
        }
    }
    private void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
