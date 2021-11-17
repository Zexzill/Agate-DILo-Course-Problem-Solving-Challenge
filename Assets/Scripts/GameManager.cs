using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const string CIRCLE_TAG = "circle";
    public const string MANAGER_TAG = "manager";
    public const string SHIELD_TAG = "shield";
    public const string OBSTACLE_TAG = "obstacle";
    public const string OBSTACLEWALL_TAG = "obstacleWall";

    public Text ScoreText;
    public Text LivesText;
    public Text TutorialButtonText;

    public Button TutorialButton;

    public GameObject TutorialPanel;

    private int _score = 0;
    private int _lives = 3;

    private bool isTutorialPanelOpened = false;

    private void Start()
    {
        _lives = 3;
        TutorialButton.onClick.AddListener(OpenTutorialPanel);
    }

    private void OpenTutorialPanel()
    {
        isTutorialPanelOpened = !isTutorialPanelOpened;

        TutorialPanel.SetActive(isTutorialPanelOpened);
        
        TutorialButtonText.text = isTutorialPanelOpened ? $"CLOSE" : $"TUTORIAL";

        Time.timeScale = isTutorialPanelOpened ? 0 : 1;
    }

    public void IncreaseScore(int value)
    {
        ScoreText.text = $"skor {(_score += value)}";
    }

    public void DecreaseLives(int value)
    {
        LivesText.text = $"lives {_lives -= value}";
        if(_lives <= 0)
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
