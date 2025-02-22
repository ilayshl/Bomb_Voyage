using UnityEngine;

/// <summary>
/// Holds statistics and general usage in the main game.
/// </summary>
public class GameManager : MonoBehaviour
{
    public int gamesWon {get; private set;}
    [SerializeField] private GameObject[] gameTypes;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject activeGame;
    [SerializeField] private GameObject bombExplosion;
    private int score;
    private UIManager _uiManager;
    private AudioManager _audioManager;
    private ScoreManager _scoreManager;
    private TimeManager _timeManager;

    void Awake()
    {
        _uiManager = GetComponent<UIManager>();
        _audioManager = GetComponentInChildren<AudioManager>();
        _scoreManager = GetComponent<ScoreManager>();
        _timeManager = GetComponent<TimeManager>();
    }

    private void Start()
    {
        _audioManager.PlaySound("MainMusic");
    }

    /// <summary>
    /// Start a random game, by an index of gameTypes.
    /// </summary>
    /// <param name="game"></param>
    private void InitiateGame()
    {
        ResetGame();
        int game = Random.Range(0, gameTypes.Length);
        Instantiate(gameTypes[game], activeGame.transform.position, Quaternion.identity, activeGame.transform);
    }


    /// <summary>
    /// Resets the game.
    /// </summary>
    private void ResetGame()
    {
       
        foreach (Transform transform in activeGame.transform)
        {
            Destroy(transform.gameObject);
        }
    }


    /// <summary>
    /// On losing a game, exploding everything.
    /// </summary>
    public void OnLose()
    {
        _audioManager.StopSound("MainMusic");
        _audioManager.PlaySound("BombExplosion");
        var glow = Instantiate(bombExplosion);
        const float DELAY = 1.3f;
        _uiManager.EnableLoseScreen(true, DELAY, score);
        _timeManager.ClearTimer();
        Invoke("ResetGame", DELAY);
        Destroy(glow, DELAY);
    }

    /// <summary>
    /// Resets the game and starts another one in succession.
    /// </summary>
    public void OnWin(int scoreAddition)
    {
        _audioManager.PlayRandomWin();
        ResetGame();
        InitiateGame();
        _timeManager.AddTime();
        gamesWon++;
        score+=scoreAddition;
    }

    /// <summary>
    /// Starts the game on play button press.
    /// </summary>
    public void OnPlayButtonPress()
    {
        _audioManager.PlaySound("Click");
        _uiManager.DisableMainMenu();
        _uiManager.EnableLoseScreen(false);
        _uiManager.EnableGameplayBackground(true);
        InitiateGame();
        _timeManager.NewTimer();
        gamesWon = 0;
        score = 0;
    }
    public void OnTryAgainButtonPress()
    {
        _audioManager.PlaySound("MainMusic");
        _audioManager.PlaySound("Click");
        _uiManager.DisableMainMenu();
        _uiManager.EnableLoseScreen(false);
        InitiateGame();
        _timeManager.NewTimer();
        gamesWon = 0;
        score = 0;
    }
}
