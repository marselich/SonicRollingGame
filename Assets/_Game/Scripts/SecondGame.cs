using UnityEngine;

public class SecondGame : MonoBehaviour
{
    [SerializeField] private GameObject _winTrigger;
    [SerializeField] private GameObject _sonicDancer;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _bagroundSound;

    private void Awake()
    {
        BoxCollider winBoxCollider = _winTrigger.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _winTrigger)
        {
            _sonicDancer.SetActive(true);
            _bagroundSound.Stop();
            _winSound.Play();
        }
    }

}
