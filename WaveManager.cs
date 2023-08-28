using UnityEngine;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    // Define wave spawn points in the Unity Inspector
    public Transform[] waveSpawnPoints;

    // Define asteroid prefabs in the Unity Inspector for different sizes
    public GameObject largeAsteroidPrefab;
    public GameObject mediumAsteroidPrefab;
    public GameObject smallAsteroidPrefab;

    // Define ET enemy craft prefabs and their spawn chances in the Unity Inspector
    public GameObject purpleETPrefab;
    public GameObject greenETPrefab;
    public GameObject blueETPrefab;

    // Define ET enemy craft spawn points in the Unity Inspector
    public Transform[] etSpawnPoints;

    public float purpleETSpawnChance;
    public float greenETSpawnChance;
    public float blueETSpawnChance;

    // Define initial number of large asteroids in the first wave
    public int initialLargeAsteroids = 3;

    // Timer to track when to start a new wave
    private float waveStartTimer = 0f;

    // Number of large asteroids remaining in the current wave
    private int largeAsteroidsRemaining;

    void Start()
    {
        // Initialize the number of large asteroids for the first wave
        largeAsteroidsRemaining = initialLargeAsteroids;
    }

    void Update()
    {
        // Check if it's time to start a new wave
        waveStartTimer += Time.deltaTime;

        if (waveStartTimer >= Random.Range(20f, 30f)) // Adjust the range as needed
        {
            StartNewWave();
            waveStartTimer = 0f;
        }
    }

    void StartNewWave()
    {
        // Randomly select spawn points for large asteroids
        List<int> asteroidSpawnIndices = new List<int>();
        for (int i = 0; i < waveSpawnPoints.Length; i++)
        {
            asteroidSpawnIndices.Add(i);
        }

        // Shuffle the list of spawn indices to randomize asteroid placement
        for (int i = 0; i < asteroidSpawnIndices.Count; i++)
        {
            int temp = asteroidSpawnIndices[i];
            int randomIndex = Random.Range(i, asteroidSpawnIndices.Count);
            asteroidSpawnIndices[i] = asteroidSpawnIndices[randomIndex];
            asteroidSpawnIndices[randomIndex] = temp;
        }

        // Spawn large asteroids at random spawn points
        for (int i = 0; i < initialLargeAsteroids; i++)
        {
            int spawnIndex = asteroidSpawnIndices[i];
            Instantiate(largeAsteroidPrefab, waveSpawnPoints[spawnIndex].position, Quaternion.identity);
        }

        // Reset the count of large asteroids remaining
        largeAsteroidsRemaining = initialLargeAsteroids;

        // Spawn ET enemy craft based on spawn chances
        SpawnETCraft();
    }

    void SpawnETCraft()
    {
        // Randomly select an ET craft to spawn
        float randomValue = Random.value;

        if (randomValue <= purpleETSpawnChance)
        {
            // Spawn Purple ET craft at a random spawn point
            int spawnIndex = Random.Range(0, etSpawnPoints.Length);
            Instantiate(purpleETPrefab, etSpawnPoints[spawnIndex].position, Quaternion.identity);
        }
        else if (randomValue <= purpleETSpawnChance + greenETSpawnChance)
        {
            // Spawn Green ET craft at a random spawn point
            int spawnIndex = Random.Range(0, etSpawnPoints.Length);
            Instantiate(greenETPrefab, etSpawnPoints[spawnIndex].position, Quaternion.identity);
        }
        else if (randomValue <= purpleETSpawnChance + greenETSpawnChance + blueETSpawnChance)
        {
            // Spawn Blue ET craft at a random spawn point
            int spawnIndex = Random.Range(0, etSpawnPoints.Length);
            Instantiate(blueETPrefab, etSpawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }

    public void AsteroidDestroyed(GameObject asteroid)
    {
        // Handle asteroid destruction logic here
        // You may need to spawn smaller asteroids or update wave progress

        // Check if the destroyed asteroid was not the smallest size
        AsteroidController asteroidController = asteroid.GetComponent<AsteroidController>();
        if (asteroidController.asteroidSize > 1)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector3 spawnPosition = asteroid.transform.position + Random.insideUnitSphere * 0.5f;
                GameObject smallerAsteroid = Instantiate(mediumAsteroidPrefab, spawnPosition, Quaternion.identity);
                AsteroidController smallerAsteroidController = smallerAsteroid.GetComponent<AsteroidController>();
                smallerAsteroidController.asteroidSize = asteroidController.asteroidSize - 1;
            }
        }
    }

    // Add other methods as needed, e.g., for starting new waves and updating wave progress
}
