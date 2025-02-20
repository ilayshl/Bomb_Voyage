using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private Counter _gameTimer;
    private GameManager _gameManager;
    private UIManager _uiManager;

    private const int STARTING_TIME = 10;

    void Awake()
    {
        _gameManager = GetComponent<GameManager>();
        _uiManager = GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_gameTimer != null)
        {
            if (_gameTimer.CurrentCounter() > 0)
            {
                _gameTimer.ChangeCounter(-Time.deltaTime);
                double roundedCurrentTime = System.Math.Round(_gameTimer.CurrentCounter(), 1);
                _uiManager.SetTimerText(roundedCurrentTime);
            }
            else
            {
                _gameTimer.Amount = 0;
                timerText.text = _gameTimer.CurrentCounter().ToString();
                _gameTimer = null;
                _gameManager.OnLose();
            }

        }
    }

    /// <summary>
    /// Creats and starts a new timer with STARTING_TIME seconds.
    /// </summary>
    /// <param name="time"></param>
    public void NewTimer(int time)
    {
        if (_gameTimer == null)
        {
            _gameTimer = new Counter(STARTING_TIME);
        }

    }

    /// <summary>
    /// Adds the starting time minus 1 second for every module (%) starting time.
    /// After 10 wins, adds 4 seconds. After 20 wins, adds 3 seconds, etc.
    /// </summary>
    /// <param name="addition"></param>
    public void AddTime()
    {
        if (_gameTimer != null)
        {
            _gameTimer.ChangeCounter((STARTING_TIME / 2) - IncreaseDifficulty());
        }
    }

    /// <summary>
    /// Does the mathematical thing to decide how many seconds should be 
    /// </summary>
    /// <param name="gamesWon"></param>
    /// <returns></returns>
    private int IncreaseDifficulty()
    {
        int difficulty = 0;
        for (int i = 0; i < _gameManager.gamesWon; i++)
        {
            if (i % STARTING_TIME == 0 && i != 0)
            {
                difficulty--;
            }
        }
        return difficulty;
    }
}
