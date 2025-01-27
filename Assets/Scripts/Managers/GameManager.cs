using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
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
        animator.SetBool("IsKilled", true);
        // Esperar el tiempo de duración de la animación antes de cambiar de escena
        float deathAnimationTime = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke("ChangeScene", deathAnimationTime);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Ending");
    }
}
