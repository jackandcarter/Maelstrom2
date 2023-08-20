using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Text finalScoreText;

    void Start()
    {
        UpdateFinalScoreText();
    }

    void UpdateFinalScoreText()
    {
        finalScoreText.text = "Final Score: " + GameManager.instance.playerScore.ToString();
    }
}
