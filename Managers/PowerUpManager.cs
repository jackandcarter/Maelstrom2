using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform[] spawnPoints; // Assign spawn points in the inspector.
    public GameObject[] powerUpPrefabs; // Assign power-up prefabs in the inspector.
    public float spawnInterval = 10f; // Time interval between power-up spawns.
    public float minSpawnChance = 0.1f; // Minimum spawn chance (0-1).
    public float maxSpawnChance = 0.5f; // Maximum spawn chance (0-1).
    public float powerUpSpeed = 5f; // Speed at which power-ups float downward.
    public float powerUpLifetime = 10f; // Time before power-up despawns.

    private float nextSpawnTime;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        // Check if it's time to spawn a power-up.
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnInterval;

            // Determine if a power-up should spawn based on chance.
            float spawnChance = Random.Range(0f, 1f);
            if (spawnChance <= maxSpawnChance)
            {
                SpawnPowerUp();
            }
        }
    }

    private void SpawnPowerUp()
    {
        // Choose a random spawn point and power-up prefab.
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject powerUpPrefab = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];

        // Instantiate the power-up.
        GameObject powerUp = Instantiate(powerUpPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D powerUpRb = powerUp.GetComponent<Rigidbody2D>();

        // Apply initial force to make it float downward diagonally.
        Vector2 force = new Vector2(powerUpSpeed, -powerUpSpeed);
        powerUpRb.velocity = force;

        // Destroy the power-up after a set lifetime.
        Destroy(powerUp, powerUpLifetime);

        // Play the Power Up Appearance sound via AudioManager.
        audioManager.PlaySoundEffect(audioManager.powerUpAppearanceSound);
    }
}
