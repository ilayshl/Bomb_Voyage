using UnityEngine;

/// <summary>
/// Holds statistics and general usage in the main game.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private int startingTimer;
    [SerializeField] private GameObject[] gameTypes;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject activeGame;
    [SerializeField] private GameObject redGlow;
    private bool _isRunning;
    private Counter _gameCounter;
    private UIManager _uiManager;

    private int _gamesWon;

    void Awake()
    {
        _uiManager = GetComponent<UIManager>();
    }

    void Start()
    {
        _gameCounter = new Counter(startingTimer++);
    }

    void Update()
    {
        _gameCounter.ChangeCounter(-Time.deltaTime);
        _uiManager.SetTimerText((int)_gameCounter.CurrentCounter());
    }

    /// <summary>
    /// Start a certain game, decided by the integer in comparison to GameTypes.
    /// </summary>
    /// <param name="game"></param>
    public void InitiateGame(int game)
    {
        Debug.Log((GameType)game);
        ResetGame();
        Instantiate(gameTypes[game], activeGame.transform.position, Quaternion.identity, activeGame.transform);
    }

    /// <summary>
    /// Resets the game.
    /// </summary>
    private void ResetGame()
    {
        foreach(Transform transform in activeGame.transform)
        {
            Destroy(transform.gameObject);
        }
    }

    /// <summary>
    /// On losing a game, exploding everything.
    /// </summary>
    public void OnLose()
    {
        var glow = Instantiate(redGlow, new Vector2(transform.position.x, transform.position.y+1.5f), Quaternion.identity);
        Invoke("ResetGame", 4);
        Destroy(glow, 4);
        Debug.Log("You broke bad after " + _gamesWon + " successful bombs disposed... Too bad.");
    }

    public void OnWin()
    {
        ResetGame();
        InitiateGame(Random.Range(0, gameTypes.Length));
        _gamesWon++;
    }
}
