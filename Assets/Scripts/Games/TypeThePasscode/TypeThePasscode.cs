using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TypeThePasscode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI manualText;
    [SerializeField] private TextMeshProUGUI hiddenPasscodeText;
    private int passcode; //The passcode generated. this may not change once set.
    private int typedPasscode; //The passcode that the player types.
    private bool isLost = false;
    private GameManager _gameManager;
    private AudioManager _audioManager;
    private UIManager _uiManager;


    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = _gameManager.GetComponentInChildren<AudioManager>();
        _uiManager = _gameManager.GetComponent<UIManager>();
    }

    void Start()
    {
        _uiManager.ChangeTimerReference(timerText);
        passcode = GeneratePasscode();
        manualText.SetText(passcode.ToString());
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

        if (!isLost)
        {
            _audioManager.PlayKeyNumber(number);
            typedPasscode = (typedPasscode * 10) + number;
            UpdateHiddenPasscode();
            if (typedPasscode == passcode)
            {
                GetComponent<Animator>().SetTrigger("gameWon");
            }
        }
        if (typedPasscode > 999999 && !isLost)
        {
            _gameManager.OnLose();
            isLost = true;
        }

    }



    /// <summary>
    /// Deletes the last digit from the typed passcode.
    /// </summary>
    public void DeleteDigit()
    {
        _audioManager.PlaySound("DeleteDigit_Type");
        float temporaryPasscode = typedPasscode / 10;
        typedPasscode = (int)temporaryPasscode;
        UpdateHiddenPasscode();
    }

    /// <summary>
    /// When the game is won.
    /// </summary>
    public void OnWin()
    {
        _gameManager.OnWin(85);
    }
    
    /// <summary>
    /// Updates the string to match the amount of digits currently in the typedPasscode.
    /// </summary>
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
