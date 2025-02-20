using TMPro;
using UnityEngine;

public class TypeThePasscode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int passcode; //The passcode generated. this may not change once set.
    private int typedPasscode;

    private GameManager _gameManager;
    private AudioManager _aManager;

    private bool gameLost=false;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _aManager = _gameManager.GetComponentInChildren<AudioManager>();
    }

    void Start()
    {
        passcode = GeneratePasscode();
        text.SetText(passcode.ToString());
    }

    /// <summary>
    /// Generates a radom 6 digits passcode.
    /// </summary>
    /// <returns></returns>
    private int GeneratePasscode()
    {
        int random = Random.Range(100000, 999999);
        return random;
    }

    /// <summary>
    /// If the game isn't lost already, adds the given digit to the typed passcode.
    /// </summary>
    /// <param name="number"></param>
    public void PressKeypad(int number)
    {
        if (!gameLost)
        {
        typedPasscode = (typedPasscode * 10) + number;
        if (typedPasscode == passcode)
        {
            GetComponent<Animator>().SetTrigger("gameWon");
        }
            _aManager.PlayKeyNumber(number);
            typedPasscode = (typedPasscode * 10) + number;
            if (typedPasscode == passcode)
            {
                GetComponent<Animator>().SetTrigger("gameWon");
            }
        }
        if (typedPasscode > 999999 && !gameLost)
        {
            //PlaySound(Error);
            _gameManager.OnLose();
            gameLost = true;
        }

    }

    /// <summary>
    /// Deletes the last digit from the typed passcode.
    /// </summary>
    public void DeleteDigit()
    {
        float temporaryPasscode = typedPasscode/10;
        typedPasscode = (int)temporaryPasscode;
    }

    /// <summary>
    /// When the game is won.
    /// </summary>
    public void OnWin()
    {
        _gameManager.OnWin();
    }
}
