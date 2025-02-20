using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Transform mainMenuUI;
    [SerializeField] private Transform loseScreenUI;
    [SerializeField] private Transform storyUI;
    [SerializeField] private Transform creditsUI;

    /// <summary>
    /// Sets the text of the timer.
    /// </summary>
    /// <param name="timer"></param>
    public void SetTimerText(double timer)
    {
        timerText.SetText(timer.ToString());
    }

    /// <summary>
    /// Sets main menu off.
    /// </summary>
    public void DisableMainMenu()
    {
        mainMenuUI.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
    }

    /// <summary>
    /// Sets lose screen on.
    /// </summary>
     private void EnableLoseScreen()
    {
        loseScreenUI.gameObject.SetActive(true);
    }

    /// <summary>
    /// Calls the Lose screen after 'time' seconds.
    /// </summary>
    /// <param name="time"></param>
    public void InvokeLoseScreen(float time)
    {
        Invoke("EnableLoseScreen", time);
    }

    /// <summary>
    /// Base game screen.
    /// </summary>
    public void BackToMainMenu()
    {
        mainMenuUI.gameObject.SetActive(true);
        loseScreenUI.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
    }
    
}
