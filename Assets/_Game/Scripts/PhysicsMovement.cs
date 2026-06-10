using UnityEngine;

public class PhysicsMovement
{
    private float _moveSpeed;
    private float _rotationSpeed;
    private float _jumpForce;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private Vector3 _lastDirection;

    public PhysicsMovement(Rigidbody rigidBody, float moveSpeed, float rotationSpeed, float jumpForce)
    {
        _rigidbody = rigidBody;
        _moveSpeed = moveSpeed;
        _rotationSpeed = rotationSpeed;
        _direction = Vector3.zero;
        _jumpForce = jumpForce;
        _lastDirection = Vector3.right;
    }

    public Vector3 Direction { set => _direction = value; }
    public Vector3 NormalizedDirection => _direction.normalized;

    public void ForceMove()
    {
        if (NormalizedDirection != Vector3.zero)
            _lastDirection = _direction;
        else
            return;

        _rigidbody.AddForce(NormalizedDirection * _moveSpeed, ForceMode.Force);
        ProcessRotate();
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void ResetRotation()
    {
        _rigidbody.rotation = Quaternion.LookRotation(_lastDirection);
    }

    private void ProcessRotate()
    {
        Quaternion lookRotation = Quaternion.LookRotation(NormalizedDirection);
        float step = _rotationSpeed * Time.deltaTime;

        _rigidbody.rotation = Quaternion.RotateTowards(_rigidbody.rotation, lookRotation, step);
    }

    public bool IsVelocityZero => _rigidbody.velocity == Vector3.zero;
}
