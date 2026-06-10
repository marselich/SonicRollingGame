using UnityEngine;

public class SonicRollingGame : MonoBehaviour
{
    private const string LoseText = "Вы проиграли!";
    private const string WinText = "Вы выиграли!";

    [SerializeField] private Player _player;
    [SerializeField] private float _loseTime;
    [SerializeField] private GameObject _rings;

    private bool _isPlaying;
    private int _ringsCount;
    private float _gameTime;

    private void Awake()
    {
        _isPlaying = true;
        _ringsCount = _rings.transform.childCount;
    }

    private void Update()
    {
        if (_isPlaying == false)
            return;

        _gameTime += Time.deltaTime;

        Debug.Log("Время игры: " + _gameTime);

        if (_gameTime >= _loseTime)
            Lose();

        if (_player.CoinsCount == _ringsCount)
            Win();
    }

    private void Lose()
    {
        Debug.Log(LoseText);
        _isPlaying = false;
    }

    private void Win()
    {
        Debug.Log(WinText);
        _isPlaying = false;
    }
}
