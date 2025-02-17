using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;

    /// <summary>
    /// Sets the text of the timer.
    /// </summary>
    /// <param name="timer"></param>
    public void SetTimerText(int timer)
    {
        counterText.SetText(timer.ToString());
    }
}
