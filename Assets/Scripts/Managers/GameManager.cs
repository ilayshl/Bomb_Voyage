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
        _audioManager.PlaySound("BombExplosion");
        var glow = Instantiate(bombExplosion, new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
        _uiManager.InvokeLoseScreen(1.5f);
        Invoke("ResetGame", 1.5f);
        Destroy(glow, 1.5f);
    }

    /// <summary>
    /// Resets the game and starts another one in succession.
    /// </summary>
    public void OnWin()
    {
        _audioManager.PlayRandomWin();
        ResetGame();
        InitiateGame();
        _timeManager.AddTime();
        gamesWon++;
    }

    /// <summary>
    /// Starts the game on play button press.
    /// </summary>
    public void OnPlayButtonPress()
    {
        _uiManager.DisableMainMenu();
        InitiateGame();
        _timeManager.NewTimer(10);
    }
}
