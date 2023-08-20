using UnityEngine;

public class RandomEventController : MonoBehaviour
{
    void Start()
    {
        // Set up event probability and timer logic
        float randomValue = Random.value;

        if (randomValue < 0.1f) // 10% chance for event to occur
        {
            TriggerEvent();
        }
    }

    void TriggerEvent()
    {
        // Handle event trigger logic
        // Instantiate event prefab and apply its effect
    }
}
