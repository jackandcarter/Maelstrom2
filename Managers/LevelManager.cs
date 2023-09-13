using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [Header("GamePlay UI Elements")]
    public Text playerScoreText; // UI element for displaying player's score.
    public Text levelPointsText; // UI element for displaying level points.
    public Text bonusPointsText; // UI element for displaying bonus points.
    public Text levelTimeText; // UI element for displaying level time.
    public Text levelNumberText; // UI element for displaying the current level number.
    public GameObject levelWinPanel; // UI panel for displaying level win information.

    [Header("Level Win UI Panel Text Elements")]
    public Text currentLevelPointsText; // Text element for displaying current level points.
    public Text remainingBonusPointsText; // Text element for displaying remaining bonus points.
    public Text playerTotalScoreText; // Text element for displaying player's total score.

    [Header("Gameplay Settings")]
    public float levelWinDelay = 3f; // Delay after winning level before progressing to the next.
    public float respawnDelay = 2f; // Delay before respawning the player's ship.
    public GameObject playerShip; // Reference to the player's ship for respawning.
    public Transform respawnPoint; // Transform for respawning the player.
    public float bonusCountdownSpeed = 1f; // Speed at which bonus points count down.

    private int playerScore;
    private int levelPoints;
    private int bonusPoints;
    private float levelStartTime;
    private bool isLevelWon;
    private int currentLevel;
    private int playerLives;
    private float bonusCountdownTimer;

    // New property to keep track of the player's total score across all levels.
    private int playerTotalScore;

    // Singleton instance
    private static LevelManager instance;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("LevelManager");
                    instance = go.AddComponent<LevelManager>();
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        playerScore = 0;
        levelPoints = 0;
        bonusPoints = 5000;
        levelStartTime = Time.time;
        isLevelWon = false;
        currentLevel = 1;
        playerLives = 3;
        playerTotalScore = 0; // Initialize player's total score.

        levelWinPanel.SetActive(false);
        UpdateLivesText();
        UpdateLevelNumberText();
    }

    private void Update()
    {
        if (!isLevelWon)
        {
            // Update level time.
            UpdateLevelTimeText();

            // Update bonus points countdown.
            UpdateBonusPoints();
        }
    }

    public void AddScore(int points)
    {
        playerScore += points;

        // Update player score UI element.
        UpdatePlayerScoreText();
    }

    public void AddLevelPoints(int points)
    {
        levelPoints += points;

        // Update level points UI element.
        UpdateLevelPointsText();
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public float GetLevelStartTime()
    {
        return levelStartTime;
    }

    public float GetLevelDuration()
    {
        return Time.time - levelStartTime;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void WinLevel()
    {
        isLevelWon = true;

        // Add the current level's level points to the total level points
        playerTotalScore += levelPoints;

        // Add any remaining bonus points to the total level points.
        playerTotalScore += bonusPoints;

        // Display level win information in the UI panel.
        playerScoreText.text = "Player Score: " + playerScore;
        levelPointsText.text = "Level Points: " + levelPoints;
        bonusPointsText.text = "Bonus Points: " + bonusPoints;
        levelWinPanel.SetActive(true);

        // Add the total score to the player's score.
        playerScore += playerTotalScore;
        UpdatePlayerScoreText();

        // Reset level points and bonus points for the next level.
        levelPoints = 0;
        bonusPoints = 5000;

        StartCoroutine(LevelWinDelay());
    }

    // Function to add points to the current level's level points
    public void AddPointsToCurrentLevel(int points)
    {
        levelPoints += points;
        UpdateLevelPointsText();
    }

    private void UpdatePlayerScoreText()
    {
        if (playerScoreText != null)
        {
            playerScoreText.text = "Score: " + playerScore;
        }
    }

    private void UpdateLevelPointsText()
    {
        if (levelPointsText != null)
        {
            levelPointsText.text = "Level Points: " + levelPoints;
        }
    }

    private void UpdateLevelTimeText()
    {
        if (levelTimeText != null)
        {
            int minutes = Mathf.FloorToInt(GetLevelDuration() / 60);
            int seconds = Mathf.FloorToInt(GetLevelDuration() % 60);
            levelTimeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void UpdateBonusPoints()
    {
        if (bonusPoints > 0)
        {
            // Increment the bonus countdown timer
            bonusCountdownTimer += Time.deltaTime;

            // Calculate how many points to deduct based on the bonusCountdownSpeed
            int pointsToDeduct = Mathf.FloorToInt(bonusCountdownTimer * bonusCountdownSpeed);

            // Only deduct points if we need to
            if (pointsToDeduct > 0)
            {
                bonusPoints = Mathf.Max(0, bonusPoints - pointsToDeduct);

                // Update bonus points UI element.
                if (bonusPointsText != null)
                {
                    bonusPointsText.text = "Bonus Points: " + bonusPoints;
                }

                // Reset the bonus countdown timer
                bonusCountdownTimer = 0f;
            }
        }
    }

    private IEnumerator LevelWinDelay()
    {
        // Wait for the level win delay.
        yield return new WaitForSeconds(levelWinDelay);

        // Reset level start time.
        levelStartTime = Time.time;

        // Increment the current level.
        currentLevel++;

        // Hide the level win panel.
        levelWinPanel.SetActive(false);

        // Respawn the player's ship.
        StartCoroutine(RespawnPlayerWithDelay());
    }

    private IEnumerator RespawnPlayerWithDelay()
    {
        // Wait for the respawn delay.
        yield return new WaitForSeconds(respawnDelay);

        // Reset the player's ship position and rotation.
        playerShip.transform.position = respawnPoint.position;
        playerShip.transform.rotation = Quaternion.identity;

        // We will add additional respawn logic here.

        // Set isLevelWon to false to allow gameplay to resume.
        isLevelWon = false;

        // Increment player lives if needed.
        playerLives++;
        UpdateLivesText();
        UpdateLevelNumberText();
    }

    private void UpdateLivesText()
    {
        if (playerLives > 0 && playerLives <= 3)
        {
            if (currentLevelPointsText != null)
            {
                currentLevelPointsText.text = "Current Level Points: " + playerLives;
            }
        }
    }

    private void UpdateLevelNumberText()
    {
        if (levelNumberText != null)
        {
            levelNumberText.text = "Level: " + currentLevel;
        }
    }
}
