using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private float _stepScore;
    [SerializeField] private float _stepTime;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Dino _dino;

    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;

    private float _score;
    private float _speedGame = 1;
    private int _step = 0;
    private bool _isPause = false;

    public int  Score=>(int)_score;

    private void OnEnable()
    {
        StartGame();
        _dino.onDying += GameOver;
    }
    private void OnDisable()
    {
        _dino.onDying -= GameOver;
    }


    void Update()
    {
        _score += Time.deltaTime;

        if (_score > _stepScore *_step &&_speedGame<_maxSpeed)
        {
            _speedGame += _stepTime;
            Time.timeScale = _speedGame;
            _step++;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPause();
        }
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }
    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SwitchPause()
    {
        _isPause = !_isPause;
        if (_isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = _speedGame;

        }
        _pausePanel.SetActive(_isPause);
    }

}
