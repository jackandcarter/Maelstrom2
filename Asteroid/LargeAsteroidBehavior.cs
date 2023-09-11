using UnityEngine;

public class LargeAsteroidBehavior : MonoBehaviour
{
    public GameObject explosionPrefab; // Assign the explosion prefab in the Inspector.
    public GameObject mediumAsteroidPrefab; // Assign the medium asteroid prefab in the Inspector.
    public int pointValue = 10; // Points awarded to the player for destroying this asteroid.

    // Movement and rotation settings.
    public float driftSpeed = 2f;
    public float rotationSpeed = 20f;

    // Define the number of medium asteroids to spawn when destroyed.
    public int numberOfMediumAsteroidsToSpawn = 2;
    public float initialSeparationForce = 2f; // Initial force to separate medium asteroids.

    private Rigidbody2D rb;

    private void Start()
    {
        // Get the Rigidbody2D component of the asteroid.
        rb = GetComponent<Rigidbody2D>();

        // Apply initial rotation.
        rb.angularVelocity = Random.Range(-rotationSpeed, rotationSpeed);

        // Apply continuous drift force.
        Vector2 driftForce = Random.insideUnitCircle.normalized * driftSpeed;
        rb.AddForce(driftForce, ForceMode2D.Impulse);
    }

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

        // Calculate the separation angle between medium asteroids.
        float separationAngle = 360f / numberOfMediumAsteroidsToSpawn;

        for (int i = 0; i < numberOfMediumAsteroidsToSpawn; i++)
        {
            // Calculate the rotation for each medium asteroid.
            Quaternion rotation = Quaternion.Euler(0f, 0f, i * separationAngle);

            // Instantiate and separate medium asteroids.
            GameObject mediumAsteroid = Instantiate(mediumAsteroidPrefab, transform.position, rotation);
            
            // Apply initial rotation to medium asteroids.
            Rigidbody2D mediumRb = mediumAsteroid.GetComponent<Rigidbody2D>();
            mediumRb.angularVelocity = Random.Range(-rotationSpeed, rotationSpeed);
            
            // Apply continuous drift force to medium asteroids.
            Vector2 driftForce = Random.insideUnitCircle.normalized * driftSpeed;
            mediumRb.AddForce(driftForce, ForceMode2D.Impulse);
            
            // Apply initial separation force to prevent sticking.
            mediumRb.AddForce(rotation * Vector2.up * initialSeparationForce, ForceMode2D.Impulse);
        }

        // Update level points in LevelManager.
        LevelManager.Instance.AddPointsToCurrentLevel(pointValue);

        // Destroy this large asteroid.
        Destroy(gameObject);
    }
}
