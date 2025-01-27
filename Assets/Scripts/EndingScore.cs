using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EndingScore : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().text = "Score: " + ScoreManager.Instance.Score;
    }
}
