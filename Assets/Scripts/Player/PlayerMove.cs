using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 8.0f;

    Rigidbody2D _rigidbody;
    private Animator _animator;
    private float _horizontalDir; // Horizontal move direction value [-1, 1]
    [SerializeField]
    private bool _isFacingRight = true;
    public bool IsFacingRight { get { return _isFacingRight; } }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.x = _horizontalDir * Speed;
        _rigidbody.linearVelocity = velocity;
    }

    // NOTE: InputSystem: "move" action becomes "OnMove" method
    void OnMove(InputValue value)
    {
        _animator.SetBool("IsMoving", true);
        // Read value from control, the type depends on what
        // type of controls the action is bound to
        var inputVal = value.Get<Vector2>();
        _horizontalDir = inputVal.x;
        // Si hace falta, giramos el sprite
        if (_horizontalDir > 0 && !_isFacingRight || _horizontalDir < 0 && _isFacingRight)
        {
            Flip();
        }
        float moveAnimationTime = _animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke("SetAnimationFalse", moveAnimationTime);
        
    }
    void SetAnimationFalse() 
    {
        _animator.SetBool("IsMoving", false);
    }
    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
