using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{

    private Text _label;
    private int score;
    private void Awake()
    {
        _label = GetComponent<Text>();
    }
    private void UpdateScoreText(int Score)
    {
        _label.text = "Score: " + Score.ToString();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText(score);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
