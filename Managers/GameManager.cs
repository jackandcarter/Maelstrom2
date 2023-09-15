using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    public Text playerNameInputText;
    public Text playerTotalScoreText; // Text element for displaying the player's total score.

    [Header("Pause Menu UI")]
    public GameObject pauseMenuPanel;
    public Text currentLevelText; // Text element for displaying the current level.
    public Text currentScoreText; // Text element for displaying the player's current score.

    private bool isPaused = false;

    // Called when the player loses all lives or encounters a lose condition.
    public void GameOver()
    {
        // Display the game over panel.
        gameOverPanel.SetActive(true);

        // Access the LevelManager instance.
        LevelManager levelManager = LevelManager.Instance;

        // Check if the LevelManager instance exists.
        if (levelManager != null)
        {
            // Retrieve the player's current total score from LevelManager.
            int playerTotalScore = levelManager.GetPlayerScore();

            // Display the player's total score.
            playerTotalScoreText.text = "Total Score: " + playerTotalScore;
        }

        // Check if the player achieved a high score.
        if (IsHighScore())
        {
            // Enable input field for player name.
            playerNameInputText.gameObject.SetActive(true);
        }
        else
        {
            // Player's score didn't make it to the high score list.
            playerNameInputText.gameObject.SetActive(false);
        }

        // Freeze the game.
        Time.timeScale = 0f;
    }

    // Function to check if the player's score is a high score.
    private bool IsHighScore()
    {
        // Access the LevelManager instance.
        LevelManager levelManager = LevelManager.Instance;

        // Check if the LevelManager instance exists.
        if (levelManager != null)
        {
            // Retrieve the player's current total score from LevelManager.
            int finalScore = levelManager.GetPlayerScore();

            string highScoresKey = "HighScores";
            string highScoresString = PlayerPrefs.GetString(highScoresKey, "");
            int[] highScores;

            if (!string.IsNullOrEmpty(highScoresString))
            {
                // Split the stored string into an array of strings.
                string[] scoreStrings = highScoresString.Split(',');

                // Convert the string array to an integer array.
                highScores = new int[scoreStrings.Length];

                for (int i = 0; i < scoreStrings.Length; i++)
                {
                    int score;
                    if (int.TryParse(scoreStrings[i], out score))
                    {
                        highScores[i] = score;
                    }
                    else
                    {
                        // Handle parsing error if needed.
                    }
                }
            }
            else
            {
                // Initialize the highScores array if it doesn't exist.
                highScores = new int[10];
            }

            for (int i = 0; i < highScores.Length; i++)
            {
                if (finalScore > highScores[i])
                {
                    return true;
                }
            }
        }

        // Return false by default if there's no LevelManager instance.
        return false;
    }

    // Function to save the player's name and score to the high score list.
    public void SaveHighScore()
    {
        string playerName = playerNameInputText.text;

        // Access the LevelManager instance.
        LevelManager levelManager = LevelManager.Instance;

        // Check if the LevelManager instance exists.
        if (levelManager != null)
        {
            // Retrieve the player's current total score from LevelManager.
            int playerScore = levelManager.GetPlayerScore();

            // Convert the integer array to a comma-separated string.
            string highScoresKey = "HighScores";
            string highScoresString = PlayerPrefs.GetString(highScoresKey, "");
            int[] highScores;

            if (!string.IsNullOrEmpty(highScoresString))
            {
                // Split the stored string into an array of strings.
                string[] scoreStrings = highScoresString.Split(',');

                // Convert the string array to an integer array.
                highScores = new int[scoreStrings.Length];

                for (int i = 0; i < scoreStrings.Length; i++)
                {
                    int score;
                    if (int.TryParse(scoreStrings[i], out score))
                    {
                        highScores[i] = score;
                    }
                    else
                    {
                        // Handle parsing error if needed.
                    }
                }
            }
            else
            {
                // Initialize the highScores array if it doesn't exist.
                highScores = new int[10];
            }

            // Add the player's score to the high scores list.
            for (int i = 0; i < highScores.Length; i++)
            {
                if (playerScore > highScores[i])
                {
                    // Shift existing scores down to make room for the new score.
                    for (int j = highScores.Length - 1; j > i; j--)
                    {
                        highScores[j] = highScores[j - 1];
                    }

                    highScores[i] = playerScore;
                    break;
                }
            }

            // Convert the updated integer array to a comma-separated string.
            highScoresString = string.Join(",", highScores);

            // Save the updated high scores list.
            PlayerPrefs.SetString(highScoresKey, highScoresString);
            PlayerPrefs.Save(); // Save the changes to PlayerPrefs.
        }
    }

    // Function to restart the game.
    public void RestartGame()
    {
        // Reload the current scene to restart the game.
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    // Function to return to the main menu.
    public void ReturnToMainMenu()
    {
        // Load the main menu scene.
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your actual main menu scene name.
    }

    // Function to handle pausing and resuming the game.
    public void TogglePause()
    {
        isPaused = !isPaused;

        // Pause or resume the game based on the current state.
        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game.
            pauseMenuPanel.SetActive(true); // Show the pause menu panel.

            // Access the LevelManager instance.
            LevelManager levelManager = LevelManager.Instance;

            // Update the current level and player's current score UI elements.
            if (levelManager != null)
            {
                currentLevelText.text = "Level: " + levelManager.GetCurrentLevel();
                currentScoreText.text = "Score: " + levelManager.GetPlayerScore();
            }
        }
        else
        {
            Time.timeScale = 1f; // Resume the game.
            pauseMenuPanel.SetActive(false); // Hide the pause menu panel.
        }
    }

    // Function to resume the game from the pause menu.
    public void ResumeGame()
    {
        TogglePause(); // Resume the game by toggling pause off.
    }
}
