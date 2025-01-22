using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]
    private LayerMask WhatIsGround;
    [SerializeField]
    private LayerMask WhatIsPlatform;

    [SerializeField]
    private Transform GroundCheckPoint;
    [SerializeField]
    private Transform FrontCheckPoint;
    [SerializeField]
    private Transform RoofCheckPoint;

    public Transform CurrentPlatform;

    private float _checkRadius = 0.15f;
    private bool _wasGrounded;

    [SerializeField]
    private bool _isGrounded;
    public bool IsGrounded { get { return _isGrounded || _isPlatformGround; } }

    [SerializeField]
    private bool _isTouchingFront;
    public bool IsTouchingFront { get { return _isTouchingFront; } }

    [SerializeField]
    private bool _isPlatformGround;
    public bool IsPlatForm { get { return _isPlatformGround; } }

    [SerializeField]
    private float _distanceToGround;
    public float DistanceToGround { get { return _distanceToGround; } }

    [SerializeField]
    private float _groundAngle;
    public float GroundAngle { get { return _groundAngle; } }

    void FixedUpdate()
    {
        // NOTE: Physics are recommended to be updated at fixed time steps
        // so logic is added to FixedUpdate() method

        CheckCollisions();
        CheckDistanceToGround();
    }
    private void CheckCollisions()
    {
        CheckGrounded();
        CheckPlatformed();
        CheckFront();
    }

    private void CheckGrounded()
    {
        var colliders = Physics2D.OverlapCircleAll(GroundCheckPoint.position, _checkRadius, WhatIsGround);

        _isGrounded = (colliders.Length > 0);

        //if (!_wasGrounded && _isGrounded) SendMessage("OnLanding");
        //_wasGrounded = _isGrounded;
    }
    private void CheckPlatformed()
    {
        var colliders = Physics2D.OverlapCircleAll(GroundCheckPoint.position, _checkRadius, WhatIsPlatform);

        _isPlatformGround = (colliders.Length > 0);
        if (_isPlatformGround) CurrentPlatform = colliders[0].transform;

        //if (!_wasGrounded && _isGrounded) SendMessage("OnLanding");
        //_wasGrounded = _isGrounded;
    }
    private void CheckFront()
    {
        var colliders = Physics2D.OverlapCircleAll(FrontCheckPoint.position, _checkRadius, WhatIsGround);

        _isTouchingFront = (colliders.Length > 0);
    }
    private void CheckDistanceToGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(GroundCheckPoint.position, Vector2.down, 100, WhatIsGround);

        _distanceToGround = hit.distance;
        _groundAngle = Vector2.Angle(hit.normal, new Vector2(1, 0));
    }
}
