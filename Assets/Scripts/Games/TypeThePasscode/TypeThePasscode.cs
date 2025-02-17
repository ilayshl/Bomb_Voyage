using TMPro;
using UnityEngine;

public class TypeThePasscode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int passcode;
    private int typedPasscode;

    private GameManager _gameManager;

    private bool gameLost=false;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        passcode = GeneratePasscode();
        text.SetText(passcode.ToString());
    }

    private int GeneratePasscode()
    {
        int random = Random.Range(100000, 999999);
        return random;
    }

    public void PressKeypad(int number)
    {
        if(!gameLost)
        {
        //PlayOneShot(Sound);
        typedPasscode = (typedPasscode * 10) + number;
        Debug.Log("current code is " + typedPasscode);
        if (typedPasscode == passcode)
        {
            GetComponent<Animator>().SetTrigger("gameWon");
        }
        }
        if (typedPasscode > 999999 && !gameLost)
        {
            //PlaySound(Error);
            _gameManager.OnLose();
            gameLost=true;
        }

    }

    public void DeleteDigit()
    {
        typedPasscode = ((int)passcode / 10);
    }

    public void OnWin()
    {
        _gameManager.OnWin();
    }
}
