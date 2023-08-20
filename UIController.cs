using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text livesText;
    public Text scoreText;

    void Update()
    {
        UpdateLivesText();
        UpdateScoreText();
    }

    void UpdateLivesText()
    {
        livesText.text = "Lives: " + GameManager.instance.playerLives.ToString();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.instance.playerScore.ToString();
    }
}
