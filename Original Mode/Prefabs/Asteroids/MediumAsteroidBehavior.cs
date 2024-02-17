using UnityEngine;

public class MediumAsteroidBehavior : MonoBehaviour
{
    public GameObject explosionPrefab; // Assign the explosion prefab in the Inspector.
    public GameObject smallAsteroidPrefab; // Assign the small asteroid prefab in the Inspector.
    public int pointValue = 5; // Points awarded to the player for destroying this asteroid.

    // Movement and rotation settings.
    public float driftSpeed = 2f;
    public float rotationSpeed = 20f;

    // Define the number of small asteroids to spawn when destroyed.
    public int numberOfSmallAsteroidsToSpawn = 2;
    public float initialSeparationForce = 2f; // Initial force to separate small asteroids.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet") || other.CompareTag("EnemyBullet"))
        {
            DestroyAsteroid();
        }
    }

    private void DestroyAsteroid()
    {
        // Play asteroid explosion sound.
        AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.asteroidExplosionSound);

        // Spawn the explosion prefab.
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Calculate the separation angle between small asteroids.
        float separationAngle = 360f / numberOfSmallAsteroidsToSpawn;

        for (int i = 0; i < numberOfSmallAsteroidsToSpawn; i++)
        {
            // Calculate the rotation for each small asteroid.
            Quaternion rotation = Quaternion.Euler(0f, 0f, i * separationAngle);

            // Instantiate and separate small asteroids.
            GameObject smallAsteroid = Instantiate(smallAsteroidPrefab, transform.position, rotation);
            
            // Apply initial rotation to small asteroids.
            Rigidbody2D rb = smallAsteroid.GetComponent<Rigidbody2D>();
            rb.angularVelocity = Random.Range(-rotationSpeed, rotationSpeed);
            
            // Apply continuous drift force to small asteroids.
            Vector2 driftForce = Random.insideUnitCircle.normalized * driftSpeed;
            rb.AddForce(driftForce, ForceMode2D.Impulse);
            
            // Apply initial separation force to prevent sticking.
            rb.AddForce(rotation * Vector2.up * initialSeparationForce, ForceMode2D.Impulse);
        }

        // Update player's points.
        LevelManager.Instance.AddScore(pointValue);

        // Update level points in LevelManager.
        LevelManager.Instance.AddPointsToCurrentLevel(pointValue);

        // Destroy this medium asteroid.
        Destroy(gameObject);
    }
}
