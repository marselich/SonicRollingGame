using UnityEngine;

public class RingsCollector : MonoBehaviour
{
    [SerializeField] private GameObject _rings;

    private int _collectedRingsCount;
    private Ring[] _localRings;

    private int AllRingsCount => _rings.transform.childCount;

    public void ResetRings()
    {
        _collectedRingsCount = 0;

        foreach (Ring ring in _localRings)
            ring.gameObject.SetActive(true);
    }

    public bool IsAllRingsCollected() => _collectedRingsCount == AllRingsCount;

    public string GetInfo() => $"Колечек собрано: {_collectedRingsCount} из {AllRingsCount}";

    private void Awake()
    {
        _localRings = _rings.GetComponentsInChildren<Ring>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ring>())
        {
            _collectedRingsCount++;
            other.gameObject.SetActive(false);
            Debug.Log("Колечко собрано! Колечек: " + _collectedRingsCount);
        }
    }
}
