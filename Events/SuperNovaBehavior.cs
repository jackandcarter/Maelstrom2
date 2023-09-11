using UnityEngine;

public class SuperNovaBehavior : MonoBehaviour
{
    public int healthPoints = 3; // Health points of the supernova.
    public float expansionTime = 5f; // Time it takes for the supernova to expand.
    public float minExplosionForce = 500f; // Minimum explosion force.
    public float maxExplosionForce = 1000f; // Maximum explosion force.

    private float startTime;
    private bool isExploded = false;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        // Check if the supernova should explode based on expansion time.
        if (!isExploded && Time.time - startTime >= expansionTime)
        {
            Explode();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the supernova can be damaged.
        if (!isExploded && (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("PlayerBullet")))
        {
            healthPoints--;

            // Check if health points are depleted.
            if (healthPoints <= 0)
            {
                Explode();
            }
        }
    }

    private void Explode()
    {
        isExploded = true;

        // Play the Super Nova Sound clip from the audio manager.
        AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.superNovaSound);

        // Shake the screen or apply any other explosion effects here.

        // Calculate a random explosion force.
        float explosionForce = Random.Range(minExplosionForce, maxExplosionForce);

        // Apply the explosion force to nearby objects.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f); // Adjust the radius as needed.

        foreach (Collider2D col in colliders)
        {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Apply the explosion force in a random direction.
                Vector2 forceDirection = Random.insideUnitCircle.normalized;
                rb.AddForce(forceDirection * explosionForce);
            }
        }

        // Add points to the current level in the LevelManager.
        LevelManager.Instance.AddPointsToCurrentLevel(100); // Change the point value as needed.

        // Destroy the supernova object.
        Destroy(gameObject);
    }
}
