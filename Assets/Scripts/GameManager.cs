using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerKiller.OnPlayerKilled += GameOver;
    }

    private void OnDisable()
    {
        PlayerKiller.OnPlayerKilled -= GameOver;
    }

    private void GameOver()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Animator>().SetBool("IsKilled", true);
        SceneManager.LoadScene("Ending");
    }
}
