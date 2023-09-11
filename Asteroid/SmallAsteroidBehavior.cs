using UnityEngine;

public class SmallAsteroidBehavior : MonoBehaviour
{
    public GameObject explosionPrefab; // Assign the explosion prefab in the Inspector.
    public int pointValue = 2; // Points awarded to the player for destroying this asteroid.

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

        // Update player's points.
        LevelManager.Instance.AddScore(pointValue);

        // Update level points in LevelManager.
        LevelManager.Instance.AddPointsToCurrentLevel(pointValue);

        // Destroy this small asteroid.
        Destroy(gameObject);
    }
}
