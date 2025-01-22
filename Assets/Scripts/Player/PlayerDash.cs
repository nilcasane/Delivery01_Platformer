using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float DashingForce = 20f;
    private bool CanDash = true;
    private PlayerMovement playerMovement;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && CanDash)
        {
            playerMovement.IsDashing = true;
            rb.linearVelocity = new Vector2(DashingForce * Mathf.Sign(transform.localScale.x), rb.linearVelocity.y);
            StartCoroutine(ResetToNormalState());
        }
    }
    //Al acabar el dash devolvemos al jugador a su estado base
    private IEnumerator ResetToNormalState()
    {
        //Esperamos un poco para no entra en conflicto con el script de movimiento
        yield return new WaitForSeconds(0.15f); // Pausa breve para permitir el salto
        playerMovement.IsDashing = false;
        CanDash = false;
        yield return new WaitForSeconds(0.35f); // Pausa breve para bloquear el dash
        CanDash = true;
    }
}
