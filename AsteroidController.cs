using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject smallAsteroidPrefab; // Reference to the smaller asteroid prefab
    public int wavePoints = 100;
    public int hitsRequired = 1;

    private int currentHits = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            currentHits++;

            if (currentHits >= hitsRequired)
            {
                DestroyAsteroid();
                GameManager.instance.IncreaseScore(wavePoints);
            }
        }
    }

    void DestroyAsteroid()
    {
        // Play destruction animation or sound
        Destroy(gameObject);

        // Split into smaller asteroids
        for (int i = 0; i < 2; i++)
        {
            Instantiate(smallAsteroidPrefab, transform.position, Quaternion.identity);
        }
    }
}
