using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TypeThePasscode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI hiddenPasscodeText;
    private int passcode; //The passcode generated. this may not change once set.
    private int typedPasscode;
    private bool gameLost = false;

    private GameManager _gameManager;
    private AudioManager _audioManager;


    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = _gameManager.GetComponentInChildren<AudioManager>();
    }

    void Start()
    {
        passcode = GeneratePasscode();
        text.SetText(passcode.ToString());
        hiddenPasscodeText.text = "";
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

        _audioManager.PlayKeyNumber(number);

        if (!gameLost)
        {
            _audioManager.PlayKeyNumber(number);
            typedPasscode = (typedPasscode * 10) + number;
            UpdateHiddenPasscode();
            Debug.Log(typedPasscode);
            if (typedPasscode == passcode)
            {
                GetComponent<Animator>().SetTrigger("gameWon");
            }
        }
        if (typedPasscode > 999999 && !gameLost)
        {
            //_audioManager.PlaySound("BombExplosion");
            _gameManager.OnLose();
            gameLost = true;
        }

    }

    /// <summary>
    /// Deletes the last digit from the typed passcode.
    /// </summary>
    public void DeleteDigit()
    {
        float temporaryPasscode = typedPasscode / 10;
        typedPasscode = (int)temporaryPasscode;
        UpdateHiddenPasscode();
    }

    /// <summary>
    /// When the game is won.
    /// </summary>
    public void OnWin()
    {
        _gameManager.OnWin();
    }

    private void UpdateHiddenPasscode()
    {
        string hiddenPasscode = typedPasscode.ToString();
        for (int i = 0; i <= 9; i++)
        {
            hiddenPasscode = hiddenPasscode.Replace(i.ToString(), "*");
        }
        if(typedPasscode == 0)
        {
            hiddenPasscode = "";
        }
        hiddenPasscodeText.text = hiddenPasscode;
    }
}
