using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public static Action<int> OnScoreUpdated;
    public void OnEnable()
    {
        Coin.OnCoinCollected += UpdateScore;
    }
    public void OnDisable()
    {
        Coin.OnCoinCollected -= UpdateScore;
    }
    private void UpdateScore(Coin coin)
    {
        Score += coin.Value;
        OnScoreUpdated?.Invoke(Score);
    }
   
}
