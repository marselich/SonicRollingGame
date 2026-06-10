using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";
    private const string IsRollingKey = "IsRolling";

    [SerializeField] private float _moveSpeed = 30f;
    [SerializeField] private float _rotationSpeed = 100;
    [SerializeField] private Animator _animator;

    private bool _isMoving;

    public PhysicsMovement PhysicsMovement { get; private set; }

    private void Awake()
    {
        _isMoving = false;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        PhysicsMovement = new PhysicsMovement(rigidbody, _moveSpeed, _rotationSpeed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PhysicsMovement.Jump();
        }

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
        if (_isMoving)
            PhysicsMovement.ForceMove();
    }
}
