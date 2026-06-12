using UnityEngine;

public class EnvironmentRotater : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] private float _rotationSpeed;

    private Rigidbody _rigidbody;
    private bool _isRotate;
    private Vector3 _rotateDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rotateDirection = new Vector3(Input.GetAxis(VerticalAxisName), 0, -Input.GetAxis(HorizontalAxisName));

        if (_rotateDirection != Vector3.zero)
            _isRotate = true;
        else
            _isRotate = false;
    }

    private void FixedUpdate()
    {
        if (_isRotate)
        {
            Quaternion rotateDirection = Quaternion.Euler(_rotateDirection * _rotationSpeed);
            _rigidbody.MoveRotation(_rigidbody.rotation * rotateDirection);
        }

    }
}
