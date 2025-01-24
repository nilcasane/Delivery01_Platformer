using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWallJump : MonoBehaviour
{
    [Header("Wall Jump Settings")]
    [SerializeField] private float wallJumpForce = 20f;
    [SerializeField] private Vector2 wallJumpDirection = new Vector2(1f, 1.5f);

    // Referencias
    private Rigidbody2D rb;
    //private PlayerMovement playerMovement;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerMovement = GetComponent<PlayerMovement>();
    }
    /*public void OnWallJump(InputAction.CallbackContext context)
    {
        if (context.performed && playerMovement.IsWallSliding)
        {
            rb.linearVelocityX = -wallJumpDirection.x * wallJumpForce * Mathf.Sign(transform.localScale.x);
            rb.linearVelocityY = wallJumpDirection.y * wallJumpForce;
        }
    }*/
 }
