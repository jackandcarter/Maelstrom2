using UnityEngine;
using UnityEngine.UI;

public class AsteroidManager : MonoBehaviour
{
    public GameObject asteroidPrefab; // Assign the asteroid prefab to be spawned.
    public int initialAsteroidCount = 3; // Initial number of asteroids to spawn in level 1.
    public Text asteroidCountText; // Assign the UI text element to display the current asteroid count.
    public Transform[] spawnPoints; // Assign spawn points in the inspector.

    private int currentLevel = 1; // Current level starts at 1.
    private int asteroidCount; // Current asteroid count.

    private void Start()
    {
        SpawnAsteroids(initialAsteroidCount);
        UpdateAsteroidCountUI();
    }

    // Method to spawn asteroids based on the specified count.
    private void SpawnAsteroids(int count)
    {
        int spawnPointIndex = 0;

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition(spawnPointIndex);
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            spawnPointIndex = (spawnPointIndex + 1) % spawnPoints.Length;
        }
    }

    // Method to get a random spawn position that doesn't overlap with existing asteroids.
    private Vector3 GetRandomSpawnPosition(int spawnPointIndex)
    {
        Vector3 spawnPosition;
        bool isOverlapping;

        // Attempt to find a non-overlapping position within a certain number of tries.
        int maxTries = 10;
        int tries = 0;

        do
        {
            spawnPosition = spawnPoints[spawnPointIndex].position;
            isOverlapping = IsOverlappingAsteroid(spawnPosition);
            tries++;
        }
        while (isOverlapping && tries < maxTries);

        return spawnPosition;
    }

    // Method to check if a spawn position overlaps with existing asteroids.
    private bool IsOverlappingAsteroid(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 1f); // Adjust the radius as needed.

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Asteroid"))
            {
                return true; // There is an overlapping asteroid.
            }
        }

        return false; // No overlapping asteroid found.
    }

    // Method to update the UI text displaying the current asteroid count.
    private void UpdateAsteroidCountUI()
    {
        asteroidCount = GameObject.FindGameObjectsWithTag("Asteroid").Length;

        if (asteroidCountText != null)
        {
            asteroidCountText.text = "Asteroids: " + asteroidCount.ToString();
        }
    }

    // Method to be called at the start of each level to spawn asteroids.
    public void StartLevel(int level)
    {
        currentLevel = level;
        int asteroidsToSpawn = initialAsteroidCount + (currentLevel - 1);
        SpawnAsteroids(asteroidsToSpawn);
        UpdateAsteroidCountUI();
    }
}
