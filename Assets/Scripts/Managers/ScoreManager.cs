using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField]
    public int Score;
    public static Action<int> OnScoreUpdated;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
    public void Reset()
    {
        Score = 0;
    }
}
