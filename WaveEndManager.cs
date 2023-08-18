using UnityEngine;
using UnityEngine.UI;

public class WaveEndManager : MonoBehaviour
{
    public Text waveNumberText;
    public Text enemiesDefeatedText;
    public Text pointsText;

    private int waveNumber;
    private int enemiesDefeated;
    private int points;

    private float continueDelay = 10f;

    private void Start()
    {
        // Get the wave number, enemies defeated and points from your game manager or other relevant script
        waveNumber = 5; // Replace with your own implementation
        enemiesDefeated = 10; // Replace with your own implementation
        points = 1000; // Replace with your own implementation

        // Update the wave number, enemies defeated, and points Text components
        waveNumberText.text = "Wave " + waveNumber.ToString() + " Complete";
        enemiesDefeatedText.text = "Enemies Defeated: " + enemiesDefeated.ToString();
        pointsText.text = "Points: " + points.ToString();

        // Automatically continue to the next wave or level after the specified delay
        Invoke("ContinueToNextWave", continueDelay);
    }

    private void ContinueToNextWave()
    {
        // Implement the logic to continue to the next wave or next level
        GameManager.Instance.ContinueToNextWave();
    }
}
