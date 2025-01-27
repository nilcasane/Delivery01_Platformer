using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    void OnStart()
    {
        SceneManager.LoadScene("Gameplay");
        ScoreManager.Instance.Reset();
    }
}
