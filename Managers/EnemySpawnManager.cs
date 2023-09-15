using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn.
    public Transform[] spawnPoints; // Array of spawn points for enemies.
    public float spawnInterval = 2f; // Time interval between enemy spawns.

    private float levelStartTime;
    private float levelDuration;
    private bool canSpawnEnemies = false;

    // Define spawn chances for different level ranges.
    private float[] spawnChances = { 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };

    private AudioManager audioManager; // Reference to the AudioManager.

    private void Start()
    {
        // Get a reference to the AudioManager.
        audioManager = AudioManager.Instance;

        // Get level information from the LevelManager singleton.
        LevelManager levelManager = LevelManager.Instance;
        if (levelManager != null)
        {
            levelStartTime = levelManager.GetLevelStartTime();
            levelDuration = levelManager.GetLevelDuration();

            // Check if it's past the initial 15 seconds to enable spawning.
            if (levelDuration > 15f)
            {
                canSpawnEnemies = true;
            }
        }

        // Start spawning enemies if allowed.
        if (canSpawnEnemies)
        {
            InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        if (CanSpawnEnemy())
        {
            // Randomly select an enemy prefab and spawn it at a random spawn point.
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);

            // Play the Enemy Craft Sound clip from the audio manager when an enemy spawns.
            audioManager.PlaySoundEffect(audioManager.enemyCraftSound);
        }
    }

    private bool CanSpawnEnemy()
    {
        if (!canSpawnEnemies)
        {
            return false;
        }

        // Determine the spawn chance based on the level range.
        int currentLevel = LevelManager.Instance.GetCurrentLevel();
        int levelRange = (currentLevel - 1) / 6;
        float spawnChance = spawnChances[levelRange];

        // Randomly decide whether to spawn an enemy based on the calculated spawn chance.
        return Random.value <= spawnChance;
    }

    // Additional Enemy types can be added here later.
}
