using UnityEngine;

public class SonicRollingGame : MonoBehaviour
{
    private const string LoseText = "Вы проиграли!";
    private const string WinText = "Вы выиграли!";

    [SerializeField] private RingsCollector _ringsCollector;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _loseTime;

    private bool _isPlaying;
    private float _gameTime;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartGame();

        if (_isPlaying == false)
            return;

        CountingGameTime();

        if (CheckLose())
            Lose();

        if (_ringsCollector.IsAllRingsCollected())
            Win();
    }

    private void StartGame()
    {
        _playerMovement.enabled = true;
        _isPlaying = true;
        _gameTime = 0;
        _ringsCollector.ResetRings();

        _playerMovement.StartMove();
        _playerMovement.SetStartPosition();
    }

    private void StopGame()
    {
        _isPlaying = false;
        _playerMovement.StopMove();
        _playerMovement.enabled = false;
    }

    private void CountingGameTime()
    {
        _gameTime += Time.deltaTime;
        Debug.Log("Время игры: " + _gameTime);
    }

    private bool CheckLose() => _gameTime >= _loseTime;

    private void Lose() => ShowEndingInfo(LoseText);

    private void Win() => ShowEndingInfo(WinText);

    private void ShowEndingInfo(string text)
    {
        Debug.Log($"{text} {_ringsCollector.GetInfo()}");
        StopGame();
    }
}
