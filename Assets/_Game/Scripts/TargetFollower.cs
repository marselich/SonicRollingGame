using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 newTarget = _target.position + _offset;
        float step = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, newTarget, step);
    }
}
