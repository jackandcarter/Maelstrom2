using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int asteroidSize = 1;

    private GameManager gameManager;
    private int hitsRemaining;

    private void Start()
    {
        hitsRemaining = asteroidSize;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        // Check if the asteroid is outside the screen boundaries and wrap it if needed.
        ScreenWrapObject.WrapObject(transform, Camera.main);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle player collision
            // Example: Player takes damage or loses a life
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            // Handle bullet collision
            Destroy(collision.gameObject);

            // Reduce hits remaining and check for destruction
            hitsRemaining--;

            if (hitsRemaining <= 0)
            {
                DestroyAsteroid();
            }
        }
    }

    private void DestroyAsteroid()
    {
        // Instantiate explosion
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Award points based on asteroid size
        int points = 0;
        switch (asteroidSize)
        {
            case 1:
                points = 100;
                break;
            case 2:
                points = 50;
                break;
            case 3:
                points = 20;
                break;
        }

        // Update game manager with points
        gameManager.UpdateTotalScore(points);

        // Destroy this asteroid
        Destroy(gameObject);
    }
}
