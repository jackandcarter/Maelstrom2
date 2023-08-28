using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text waveText;
    public Text scoreText;
    public Text livesText;
    public Text shieldText;
    public Text bonusText;
    public Text multiplierText;
    public Text powerUpText;
    
    private int waveNumber = 1;
    private int playerScore = 0;
    private int playerLives = 3;
    private int shieldPoints = 100;
    private int bonusPoints = 5000;
    private int coinMultiplier = 1;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        waveText.text = "Wave: " + waveNumber;
        scoreText.text = "Score: " + playerScore;
        livesText.text = "Lives: " + playerLives;
        shieldText.text = "Shield: " + shieldPoints;
        bonusText.text = "Bonus: " + bonusPoints;
        multiplierText.text = "x" + coinMultiplier;
        powerUpText.text = "Power-Up: None"; // Update this when a power-up is active
    }

    public void UpdateTotalScore(int points)
    {
        playerScore += points;
        UpdateUI();
    }

    // Add other methods as needed, e.g., for updating lives, shield, bonus, etc.
}
