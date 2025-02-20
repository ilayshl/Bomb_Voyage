using UnityEngine;

/// <summary>
/// Holds statistics and general usage in the main game.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform mainMenuUI;
    [SerializeField] private Transform loseScreenUI;
    [SerializeField] private Transform storyUI;
    [SerializeField] private Transform creditsUI;
    [SerializeField] private GameObject[] gameTypes;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject activeGame;
    [SerializeField] private GameObject redGlow;
    private Counter _gameCounter;
    private UIManager _uiManager;
    private AudioManager _audioManager;

    private int _gamesWon;

    void Awake()
    {
        _uiManager = GetComponent<UIManager>();
        _audioManager = GetComponentInChildren<AudioManager>();
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

    private void DisableMainMenu()
    {
        mainMenuUI.gameObject.SetActive(false);
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
        var glow = Instantiate(redGlow, new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
        Invoke("EnableLoseScreen", 1.5f);
        Invoke("ResetGame", 1.5f);
        Destroy(glow, 1.5f);
        Debug.Log("You broke bad after " + _gamesWon + " successful bombs disposed... Too bad.");
    }

    private void EnableLoseScreen()
    {
        loseScreenUI.gameObject.SetActive(true);
    }

    public void OnWin()
    {
        _audioManager.PlayRandomWin();
        ResetGame();
        InitiateGame();
        _gamesWon++;
    }

    public void OnPlayButtonPress()
    {
        DisableMainMenu();
        InitiateGame();
    }
}
