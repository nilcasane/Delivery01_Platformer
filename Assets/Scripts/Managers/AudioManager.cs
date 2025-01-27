using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField]
    private AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip musica;
    private void Start()
    {
        audioSource.clip = musica;
        audioSource.Play();
    }
}
