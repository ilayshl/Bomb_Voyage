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
    [SerializeField] private GameObject activeGame;
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

    public void InitiateGame(int game)
    {
        Debug.Log((GameType)game);
        foreach(Transform transform in activeGame.transform)
        {
            Destroy(transform.gameObject);
        }
        Instantiate(gameTypes[game], activeGame.transform.position, Quaternion.identity, activeGame.transform);
        /*switch(game){
            case (int)GameType.CutTheWires:
            Debug.Log((GameType)game);
            break;
            case (int)GameType.TypeThePassword:
            //code block
            break;
            case (int)GameType.HammerThePower:
            //code block
            break;
            case (int)GameType.PickTheLock:
            //code block
            break;
            case (int)GameType.AssembleTheButton:
            //code block
            break;
            case (int)GameType.FollowTheLights:
            //code block
            break;
            case (int)GameType.TargetTheBomb:
            //code block
            break;
            case (int)GameType.ExtinguishTheFuses:
            //code block
            break;
            case (int)GameType.IgnoreTheDecoy:
            //code block
            break;
        }*/
    }
}
