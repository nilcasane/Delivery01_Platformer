using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;

    [Header("Collision Check")]
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.01f;
    [SerializeField] private Transform wallCheckPoint;
    [SerializeField] private float wallCheckRadius = 0.02f;    
    
    // Referencias
    Rigidbody2D rb;
    private float horizontalInput;


    // Estados del personaje (Solo pueden ser leídos)
    public bool IsGrounded { get; private set; }
    public bool IsWallSliding { get;  set; }
    public bool IsWallJumping { get; set; }
    private bool IsTouchingWall;
    public bool IsFacingRight { get; private set; } = true;
    public bool IsDashing { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Actualizar estados
        IsGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, collisionLayer);
        IsTouchingWall = Physics2D.OverlapCircle(wallCheckPoint.position, wallCheckRadius, collisionLayer);
        IsWallSliding = IsTouchingWall && !IsGrounded;
    }
    void FixedUpdate()
    {
        if (IsWallJumping || IsDashing) return;
        
        // Aplicar movimiento horizontal
        rb.linearVelocityX = horizontalInput * moveSpeed;
        // Si hace falta, giramos el sprite
        if (horizontalInput > 0 && !IsFacingRight || horizontalInput < 0 && IsFacingRight)
        {
            Flip();
        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }    
    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
