using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class GestorPuntos : MonoBehaviour
{

    public static GestorPuntos Instance;

    [SerializeField] private float cantidadPuntos;

    private void Awake()
    {
        if (GestorPuntos.Instance == null)
        {
            GestorPuntos.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(float puntos)
    {
        cantidadPuntos += puntos;
    }
    //Mirar porque no funciona
}