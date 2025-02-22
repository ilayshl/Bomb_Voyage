using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HammerThePower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image hintImage; //The image shown in the manual
    [SerializeField] private Sprite[] hints; //The options to show in the manual
    [SerializeField] private PowerSupply[] _supplyUp;
    [SerializeField] private PowerSupply[] _supplyRight;
    [SerializeField] private PowerSupply[] _supplyDown;
    [SerializeField] private PowerSupply[] _supplyLeft;
    private List<PowerSupply> _connectedSupplies = new List<PowerSupply>();
    bool isLost=false;
    int randomDirection;

    private GameManager _gameManager;
    private AudioManager _audioManager;
    private UIManager _uiManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = _gameManager.GetComponentInChildren<AudioManager>();
        _uiManager = _gameManager.GetComponent<UIManager>();
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition -= new Vector2(70, rectTransform.anchoredPosition.y);
    }

    private void Start()
    {
        _uiManager.ChangeTimerReference(timerText);
        SetConnectedPowerSupplies(_supplyUp);
        SetConnectedPowerSupplies(_supplyRight);
        SetConnectedPowerSupplies(_supplyDown);
        SetConnectedPowerSupplies(_supplyLeft);

        SetActivePowerSupply();
    }

    /// <summary>
    /// Get a random index for the hint images.
    /// </summary>
    private void DecideOnDirection()
    {
        randomDirection = Random.Range(0, _connectedSupplies.Count);
        hintImage.sprite = hints[randomDirection];
    }

    /// <summary>
    /// Chooses 1 out of an array to set as isConected.
    /// </summary>
    /// <param name="supplies"></param>
    private void SetConnectedPowerSupplies(PowerSupply[] supplies)
    {
        int randomIndex = Random.Range(0, supplies.Length);
        supplies[randomIndex].SetConnected();
        _connectedSupplies.Add(supplies[randomIndex]);
    }

    /// <summary>
    /// Sets the active power supply that's meant to be broken.
    /// </summary>
    private void SetActivePowerSupply()
    {
        DecideOnDirection();
        _connectedSupplies.ElementAt(randomDirection).SetActiveSupply();
    }

    /// <summary>
    /// Checks if the power broken is the correct one.
    /// </summary>
    /// <param name="isConnected"></param>
    /// <param name="isActive"></param>
    public void OnPowerBreak(bool isConnected, bool isActive)
    {
        if(!isLost)
        {
        _audioManager.PlayRandomHammer();
        if (isConnected && isActive)
        {
            GetComponent<Animator>().SetTrigger("gameWon");
        }
        else
        {
            _gameManager.OnLose();
            isLost=true;
        }
        }
    }

    /// <summary>
    /// Finishes the game- gets called from the animation.
    /// </summary>
    public void OnWin()
    {
        _gameManager.OnWin(55);
    }
}
