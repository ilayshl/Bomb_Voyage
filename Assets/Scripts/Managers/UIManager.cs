using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform mainMenuUI;
    [SerializeField] private Transform loseScreenUI;
    [SerializeField] private Transform storyHeader;
    [SerializeField] private Transform creditsHeader;
    [SerializeField] private Transform mainMenuHeader;
    [SerializeField] private Transform gameplayBackground;
    [SerializeField] private Button backButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    private TextMeshProUGUI timerText;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GetComponentInChildren<AudioManager>();   
    }

    /// <summary>
    /// Sets the text of the timer.
    /// </summary>
    /// <param name="timer"></param>
    public void SetTimerText(double timer)
    {
        if(timerText!=null){ timerText.SetText(timer.ToString()); }
    }

    private void SetScoreText(int score)
    {
        if(scoreText!=null) { scoreText.SetText(score.ToString()); }
    }

    /// <summary>
    /// Changes where the time will be shown.
    /// </summary>
    /// <param name="updatedText"></param>
    public void ChangeTimerReference(TextMeshProUGUI updatedText)
    {
        timerText = updatedText;
    }

    /// <summary>
    /// Sets main menu off.
    /// </summary>
    public void DisableMainMenu()
    {
        mainMenuUI.gameObject.SetActive(false);
    }

    public void EnableGameplayBackground(bool value)
    {
        gameplayBackground.gameObject.SetActive(value);
    }

    /// <summary>
    /// Calls the Lose screen after 'time' seconds.
    /// </summary>
    /// <param name="time"></param>
    public void EnableLoseScreen(bool value, float time = 0, int score = 0)
    {
        StartCoroutine(InvokeLoseScreen(value, time));
        SetScoreText(score);
    }

    public IEnumerator InvokeLoseScreen(bool value, float time)
    {
        yield return new WaitForSeconds(time);
        loseScreenUI.gameObject.SetActive(value);
        gameplayBackground.gameObject.SetActive(!value);
    }

    /// <summary>
    /// Base game screen.
    /// </summary>
    public void BackToMainMenu()
    {
        _audioManager.PlaySound("Click");
        _audioManager.PlaySound("MainMusic");
        mainMenuUI.gameObject.SetActive(true);
        loseScreenUI.gameObject.SetActive(false);
        mainMenuHeader.gameObject.SetActive(true);
        storyHeader.gameObject.SetActive(false);
        creditsHeader.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    public void BackButton()
    {
        _audioManager.PlaySound("Click");
        mainMenuUI.gameObject.SetActive(true);
        loseScreenUI.gameObject.SetActive(false);
        mainMenuHeader.gameObject.SetActive(true);
        storyHeader.gameObject.SetActive(false);
        creditsHeader.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        if(timerText!=null) { timerText.gameObject.SetActive(false); }
    }



    public void Story()
    {
        _audioManager.PlaySound("Click");
        mainMenuHeader.gameObject.SetActive(false);
        storyHeader.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void Credits()
    {
        _audioManager.PlaySound("Click");
        mainMenuHeader.gameObject.SetActive(false);
        creditsHeader.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

}
