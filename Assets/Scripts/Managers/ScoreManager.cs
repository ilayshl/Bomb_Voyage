using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Counter _score = new Counter(0);

    public int Score()
    {
        return (int)_score.CurrentCounter();
    }

    public void AddScore(int value)
    {
        _score.ChangeCounter(value);
    }
}
