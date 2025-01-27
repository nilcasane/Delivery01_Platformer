using UnityEngine;
using UnityEngine.UI;

public class TitleScore : MonoBehaviour
{
    private Text _label;
    private void Awake()
    {
        _label = GetComponent<Text>();
    }
    private void OnEnable()
    {
        ScoreManager.OnScoreUpdated += UpdateScoreText;
    }
    private void OnDisable()
    {
        ScoreManager.OnScoreUpdated -= UpdateScoreText;
    }
    private void UpdateScoreText(int Score) {
        _label.text = "Score: " + Score.ToString();
    }
}
