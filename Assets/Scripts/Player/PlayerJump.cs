using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpHeight;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;
    public float PressTimeToMaxJump;
    public float WallSlideSpeed = 1;
    public ContactFilter2D filter;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private CollisionDetection _collisionDetection;
    private float _lastVelocityY;
    private float _jumpStartedTime;
    private int AvailableJumps = 0;
    private int MaximumJumps = 2;

    bool IsWallSliding => _collisionDetection.IsTouchingFront;

    private void OnEnable()
    {
        PowerUp.OnPowerUpCollected += UpdateJump;
    }
    private void OnDisable()
    {
        PowerUp.OnPowerUpCollected -= UpdateJump;
    }
    private void UpdateJump()
    {
        JumpHeight += 5;
        //DistanceToMaxHeight += increase;
        //PressTimeToMaxJump += increase;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collisionDetection = GetComponent<CollisionDetection>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (IsPeakReached()) TweakGravity();
        if (IsWallSliding)
        {
            SetWallSlide();
            AvailableJumps = MaximumJumps;
        }
        if (_collisionDetection.IsGrounded)
        {
            AvailableJumps = MaximumJumps;
        }
        // Si el jugador no est� en el suelo, restamos un salto.
        else if (AvailableJumps == MaximumJumps)
        {
            AvailableJumps--;
        }
    }
    
    // NOTE: InputSystem: "JumpStarted" action becomes "OnJumpStarted" method
    void OnJumpStarted()
    {
        if (AvailableJumps > 0)
        {
            _animator.SetBool("IsJumping", true);
            AvailableJumps--;
            SetGravity();
            var vel = new Vector2(_rigidbody.linearVelocity.x, GetJumpForce());
            _rigidbody.linearVelocity = vel;
            _jumpStartedTime = Time.time;
        }
    }

    // NOTE: InputSystem: "JumpFinished" action becomes "OnJumpFinished" method
    void OnJumpFinished()
    {
        _animator.SetBool("IsJumping", false);
        float fractionOfTimePressed = 1 / Mathf.Clamp01((Time.time - _jumpStartedTime) / PressTimeToMaxJump);
        _rigidbody.gravityScale *= fractionOfTimePressed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        float h = -GetDistanceToGround() + JumpHeight;
        Vector3 start = transform.position + new Vector3(-1, h, 0);
        Vector3 end = transform.position + new Vector3(1, h, 0);
        Gizmos.DrawLine(start, end);
        Gizmos.color = Color.white;
    }

    bool IsPeakReached()
    {
        bool reached = ((_lastVelocityY * _rigidbody.linearVelocity.y) < 0);
        _lastVelocityY = _rigidbody.linearVelocity.y;

        return reached;
    }

    void SetWallSlide()
    {
        // Modify player linear velocity on wall sliding
        //_rigidbody.gravityScale = 0.8f;
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x,
            Mathf.Max(_rigidbody.linearVelocity.y, -WallSlideSpeed));
    }
    private void SetGravity()
    {
        var grav = 2 * JumpHeight * (SpeedHorizontal * SpeedHorizontal) / (DistanceToMaxHeight * DistanceToMaxHeight);
        _rigidbody.gravityScale = grav / 9.81f;
    }

    private void TweakGravity()
    {
        _rigidbody.gravityScale *= 1.2f;
    }

    private float GetJumpForce()
    {
        return 2 * JumpHeight * SpeedHorizontal / DistanceToMaxHeight;
    }

    private float GetDistanceToGround()
    {
        RaycastHit2D[] hit = new RaycastHit2D[3];

        Physics2D.Raycast(transform.position, Vector2.down, filter, hit, 10);

        return hit[0].distance;
    }
}
