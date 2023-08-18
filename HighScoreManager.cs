using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public Text highScoreText;

    private void Start()
    {
        // Load the high scores from your saved data or database
        int[] highScores = LoadHighScores();

        // Update the high score Text component with the loaded scores
        UpdateHighScoreText(highScores);
    }

    private int[] LoadHighScores()
    {
        // Implement the logic to load the high scores from your saved data or database

        // For now, we'll use placeholder data
        int[] highScores = new int[] { 5000, 4000, 3000, 2000, 1000 };

        return highScores;
    }

    private void UpdateHighScoreText(int[] highScores)
    {
        // Clear the existing high score text
        highScoreText.text = "";

        // Loop through the high scores and append them to the text component
        for (int i = 0; i < highScores.Length; i++)
        {
            highScoreText.text += (i + 1).ToString() + ". " + highScores[i].ToString() + "\n";
        }
    }
}
