using UnityEngine;

public class PurpleETBehavior : MonoBehaviour
{
    public Transform[] waypoints; // Assign waypoints in the Inspector.
    public GameObject explosionPrefab; // Reference to the explosion prefab.
    public float movementSpeed = 2f; // Movement speed.
    public float fireRate = 0.5f; // Rate of fire (shots per second).
    public int hitsToDestroy = 1; // Number of hits required to destroy the craft.
    
    private int currentWaypointIndex = 0;
    private float fireCooldown = 0f;

    // Reference to the Audio Manager script.
    private AudioManager audioManager;

    private void Start()
    {
        // Initialize the position to the first waypoint.
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[currentWaypointIndex].position;
        }

        // Find the Audio Manager in the scene.
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        MoveToWaypoint();

        if (CanFire())
        {
            FireBullet();
        }
    }

    private void MoveToWaypoint()
    {
        // Check if there are waypoints.
        if (waypoints.Length == 0) return;

        // Move towards the current waypoint.
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Check if the craft has reached the current waypoint.
        if (transform.position == targetPosition)
        {
            // Move to the next waypoint or wrap around.
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private bool CanFire()
    {
        return Time.time >= fireCooldown;
    }

    private void FireBullet()
    {
        // Fire a bullet towards the player.
        if (fireRate > 0)
        {
            fireCooldown = Time.time + 1f / fireRate;

            // Implement bullet firing logic here.
            // Instantiate bullets tagged as "EnemyBullet" and shoot in the player's direction.
        }
    }

    public void TakeDamage()
    {
        hitsToDestroy--;

        if (hitsToDestroy <= 0)
        {
            DestroyCraft();
        }
    }

    private void DestroyCraft()
    {
        // Play explosion effect.
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        // Add points to the player's current level points.
        LevelManager.Instance.AddPointsToCurrentLevel(1000);

        // Play the ETCraftDeathSound from the Audio Manager.
        if (audioManager != null)
        {
            audioManager.PlaySoundEffect(audioManager.ETCraftDeathSound);
        }

        // Destroy the craft game object.
        Destroy(gameObject);
    }
}
