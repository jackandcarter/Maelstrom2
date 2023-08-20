using UnityEngine;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    public GameObject asteroidPrefab; // Reference to the asteroid prefab
    public Transform[] spawnPoints; // Array of spawn points

    private int currentWave = 1; // Current wave number
    private int startingAsteroids = 3; // Number of asteroids in the first wave
    private int maxSpawnPoints = 8; // Total number of spawn points

    private void Start()
    {
        StartNewWave(); // Start the first wave
    }

    private void StartNewWave()
    {
        // Calculate the number of asteroids for this wave
        int numberOfAsteroids = startingAsteroids + (currentWave - 1);

        // Ensure we don't exceed the maximum spawn points
        numberOfAsteroids = Mathf.Min(numberOfAsteroids, maxSpawnPoints);

        // Create a list of available spawn points
        List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);

        // Randomly select spawn points for asteroids
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            // Check if there are available spawn points
            if (availableSpawnPoints.Count == 0)
            {
                break; // No available spawn points left
            }

            // Randomly select a spawn point
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform spawnPoint = availableSpawnPoints[randomIndex];

            // Instantiate the asteroid at the selected spawn point
            Instantiate(asteroidPrefab, spawnPoint.position, Quaternion.identity);

            // Remove the selected spawn point from the available list
            availableSpawnPoints.RemoveAt(randomIndex);
        }

        // Increase the wave number for the next wave
        currentWave++;
    }
}
