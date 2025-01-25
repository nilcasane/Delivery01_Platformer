using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingGameManager : MonoBehaviour
{
    void OnStart()
    {
        SceneManager.LoadScene("Title");
    }
}
