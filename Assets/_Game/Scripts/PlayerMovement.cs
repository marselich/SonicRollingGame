using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";
    private const string IsRollingKey = "IsRolling";
    private const string GroundTag = "Ground";

    [SerializeField] private float _moveSpeed = 30f;
    [SerializeField] private float _rotationSpeed = 100;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private Animator _animator;

    private bool _isMoving;
    private bool _isJump;
    private bool _isOnGround;

    public PhysicsMovement PhysicsMovement { get; private set; }

    private void Awake()
    {
        _isMoving = false;
        _isOnGround = true;
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        PhysicsMovement = new PhysicsMovement(rigidbody, _moveSpeed, _rotationSpeed, _jumpForce);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
            _isJump = true;

        PhysicsMovement.Direction = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

        if (PhysicsMovement.NormalizedDirection != Vector3.zero)
        {
            _isMoving = true;
            _animator.SetBool(IsRollingKey, _isMoving);
        }
        else
        {
            _isMoving = false;

            if (PhysicsMovement.IsVelocityZero)
            {
                _animator.SetBool(IsRollingKey, _isMoving);
                PhysicsMovement.ResetRotation();
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isJump)
        {
            PhysicsMovement.Jump();
            _isJump = false;
        }

        if (_isMoving)
            PhysicsMovement.ForceMove();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == GroundTag)
            _isOnGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isOnGround = false;
    }
}
