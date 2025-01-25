using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    void OnStart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
