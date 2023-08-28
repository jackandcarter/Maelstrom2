using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    // Define event spawn points in the Unity Inspector
    public Transform[] eventSpawnPoints;

    // Define Power Up event prefabs in the Unity Inspector
    public GameObject[] powerUpEventPrefabs;

    // Define Wave event prefabs in the Unity Inspector
    public GameObject[] waveEventPrefabs;

    // Define Power Up event spawn chances in the Unity Inspector
    public float[] powerUpEventSpawnChances;

    // Define Wave event spawn chances in the Unity Inspector
    public float[] waveEventSpawnChances;

    // Define event durations in seconds for Power Up and Wave Events
    public float[] powerUpEventDurations;
    public float[] waveEventDurations;

    private float eventSpawnTimer = 0f; // Initialize the timer

    void Update()
    {
        // Increment the timer
        eventSpawnTimer += Time.deltaTime;

        // Check if it's time to spawn an event
        if (eventSpawnTimer >= Random.Range(10f, 20f)) // Adjust the range as needed
        {
            SpawnRandomEvent();
            eventSpawnTimer = 0f;
        }
    }

    void SpawnRandomEvent()
    {
        // Randomly select an event type to spawn
        float randomValue = Random.value;
        float cumulativeProbability = 0f;

        for (int i = 0; i < powerUpEventPrefabs.Length; i++)
        {
            cumulativeProbability += powerUpEventSpawnChances[i];

            if (randomValue <= cumulativeProbability)
            {
                // Spawn the selected Power Up event
                int spawnIndex = Random.Range(0, eventSpawnPoints.Length);
                GameObject spawnedEvent = Instantiate(powerUpEventPrefabs[i], eventSpawnPoints[spawnIndex].position, Quaternion.identity);

                // Set the event's duration
                Destroy(spawnedEvent, powerUpEventDurations[i]);

                return;
            }
        }

        // If no Power Up event is selected or it has already occurred, spawn a Wave event
        for (int i = 0; i < waveEventPrefabs.Length; i++)
        {
            cumulativeProbability += waveEventSpawnChances[i];

            if (randomValue <= cumulativeProbability)
            {
                // Spawn the selected Wave event
                int spawnIndex = Random.Range(0, eventSpawnPoints.Length);
                GameObject spawnedEvent = Instantiate(waveEventPrefabs[i], eventSpawnPoints[spawnIndex].position, Quaternion.identity);

                // Set the event's duration
                Destroy(spawnedEvent, waveEventDurations[i]);

                return;
            }
        }
    }
}
