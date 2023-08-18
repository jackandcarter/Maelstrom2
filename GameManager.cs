using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncrementScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreUI();
    }

    public void EndGame()
    {
        // Game Over logic
    }
}
