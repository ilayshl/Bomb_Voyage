using System.Collections;
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
    /// Calls the Lose screen after 'time' seconds.
    /// </summary>
    /// <param name="time"></param>
    public void EnableLoseScreen(bool value, float time = 0)
    {
        StartCoroutine(InvokeLoseScreen(value, time));
    }

    public IEnumerator InvokeLoseScreen(bool value, float time)
    {
        yield return new WaitForSeconds(time);
        loseScreenUI.gameObject.SetActive(value);
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
