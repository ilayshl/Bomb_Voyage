using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Holds statistics and general usage in the main game.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private int startingTimer;
    [SerializeField] private GameObject[] gameTypes;
    [SerializeField] private GameObject canvas;
    private Counter _counter;
    private UIManager _uiManager;

    void Awake()
    {
        _uiManager = GetComponent<UIManager>();
    }

    void Start()
    {
        _counter = new Counter(startingTimer++);
    }

    void Update()
    {
        _counter.ChangeCounter(-Time.deltaTime);
        _uiManager.SetTimerText((int)_counter.CurrentCounter());
    }

    public void InitiateGame(GameType game)
    {
        switch(game){
            case GameType.CutTheWires:
            //code block
            break;
            case GameType.TypeThePassword:
            //code block
            break;
            case GameType.HammerThePower:
            //code block
            break;
            case GameType.PickTheLock:
            //code block
            break;
            case GameType.AssembleTheButton:
            //code block
            break;
            case GameType.FollowTheLights:
            //code block
            break;
            case GameType.TargetTheBomb:
            //code block
            break;
            case GameType.ExtinguishTheFuses:
            //code block
            break;
            case GameType.IgnoreTheDecoy:
            //code block
            break;
        }
    }
}
