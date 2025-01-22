using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerJumpOLD : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 20f;
    private static int maximumJumps = 2;
    private int availableJumps = 0;

    [Header("Wall Jump Settings")]
    [SerializeField] private float wallJumpForce = 20f;
    [SerializeField] private Vector2 wallJumpDirection = new Vector2(1f, 1.5f);

    // Referencias
    Rigidbody2D rb;
    private PlayerMovement playerMovement;
    private void OnEnable()
    {
        PowerUp.OnPowerUpCollected += UpdateJump;
    }
    private void OnDisable()
    {
        PowerUp.OnPowerUpCollected -= UpdateJump;
    }
    private void UpdateJump(PowerUp powerUp) {
        jumpForce = jumpForce + powerUp.increase;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Restart jumps
        if ((playerMovement.IsGrounded || playerMovement.IsWallSliding) && availableJumps != maximumJumps) {
            availableJumps = maximumJumps;
        }        
    }
    public void Jump(InputAction.CallbackContext context)
    {
        // Si el jugador no está en el suelo, restamos un salto.
        if (!playerMovement.IsGrounded && availableJumps == maximumJumps) availableJumps--;
        // Si la tecla de salto ha sido pulsada, salta
        if (context.performed && availableJumps > 0)
        {
            if (playerMovement.IsWallSliding)
            {
                playerMovement.IsWallJumping = true;
                playerMovement.IsWallSliding = false;
                rb.linearVelocity = new Vector2(-wallJumpDirection.x * wallJumpForce * Mathf.Sign(transform.localScale.x),
                                           wallJumpDirection.y * wallJumpForce);
                availableJumps--;
                StartCoroutine(BlockHorizontalMovement());
            }
            rb.linearVelocityY = jumpForce;
            availableJumps--;
        }
        //Al soltar la tecla de salto cancela el ascenso
        if (context.canceled && rb.linearVelocity.y > 0)
        {
            rb.linearVelocityY = rb.linearVelocity.y * 0.5f;
        }
    }
    private IEnumerator BlockHorizontalMovement()
    {
        yield return new WaitForSeconds(0.2f);
        playerMovement.IsWallJumping = false;
    }
}
