using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }
}
