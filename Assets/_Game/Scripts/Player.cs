using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coinsCount;

    public int CoinsCount => _coinsCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ring>())
        {
            _coinsCount++;
            Destroy(other.gameObject);
            Debug.Log("Монетка собрана! Монеток: " + _coinsCount);

        }
    }
}
