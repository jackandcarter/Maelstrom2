using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerPrefab;
    public Transform playerSpawnPoint;
    public GameObject gameOverCanvas;
    public int playerLives = 3;
    public int playerScore = 0;

    void Awake()
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

    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
    }

    public void IncreaseScore(int points)
    {
        playerScore += points;
    }

    public void PlayerDied()
    {
        playerLives--;

        if (playerLives > 0)
        {
            SpawnPlayer();
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
public class ScreenWrapping : MonoBehaviour
{
    void Update()
    {
        WrapObjects();
    }

    void WrapObjects()
    {
        // Loop through all objects with a Collider2D component that can wrap
        Collider2D[] colliders = Physics2D.OverlapAreaAll(
            new Vector2(-10f, -10f), // Define a wrapping area that covers the entire screen
            new Vector2(10f, 10f)
        );

        foreach (Collider2D collider in colliders)
        {
            // Check if the object has a "WrapAroundScreen" method
            IScreenWrappable wrappable = collider.GetComponent<IScreenWrappable>();

            if (wrappable != null)
            {
                // Call the "WrapAroundScreen" method to handle screen wrapping
                wrappable.WrapAroundScreen();
            }
        }
    }
}