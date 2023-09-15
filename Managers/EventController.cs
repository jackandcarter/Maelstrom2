using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventController : MonoBehaviour
{
    public GameObject supernovaPrefab;
    public GameObject blackHolePrefab;
    public float minTimeBetweenEvents = 60f;
    public float maxTimeBetweenEvents = 120f;
    public Transform[] eventSpawnPoints; // Assign spawn points in the inspector.

    private float eventTimer = 0f;
    private bool isEventActive = false;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        eventTimer = Random.Range(minTimeBetweenEvents, maxTimeBetweenEvents);
    }

    private void Update()
    {
        if (!isEventActive)
        {
            eventTimer -= Time.deltaTime;
            if (eventTimer <= 0f)
            {
                SpawnRandomEvent();
                eventTimer = Random.Range(minTimeBetweenEvents, maxTimeBetweenEvents);
            }
        }
    }

    private void SpawnRandomEvent()
    {
        float randomValue = Random.value;

        if (randomValue <= 0.33f && supernovaPrefab != null)
        {
            // Spawn Supernova event.
            int spawnPointIndex = Random.Range(0, eventSpawnPoints.Length);
            Instantiate(supernovaPrefab, eventSpawnPoints[spawnPointIndex].position, Quaternion.identity);
            audioManager.PlaySoundEffect(audioManager.superNovaEventSound);
        }
        else if (randomValue <= 0.66f && blackHolePrefab != null)
        {
            // Spawn Black Hole event.
            int spawnPointIndex = Random.Range(0, eventSpawnPoints.Length);
            Instantiate(blackHolePrefab, eventSpawnPoints[spawnPointIndex].position, Quaternion.identity);
            audioManager.PlaySoundEffect(audioManager.blackHoleEventSound);
        }

        isEventActive = true;
    }

    public void EventCompleted()
    {
        // Called when an event is completed (when a Black Hole disappears).
        isEventActive = false;
    }
}
