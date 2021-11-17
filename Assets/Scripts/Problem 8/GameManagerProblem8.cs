using UnityEngine;
using UnityEngine.UI;

public class GameManagerProblem8 : MonoBehaviour
{
    public Text ScoreText;
    private int score = 0;
    public void IncreaseScore(int value)
    {
        ScoreText.text = $"skor {(score += value)}";
    }
}
