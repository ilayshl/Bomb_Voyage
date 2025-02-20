using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Counter _score = new Counter(0);

    public void AddScore(int value)
    {
        _score.ChangeCounter(value);
    }
}
