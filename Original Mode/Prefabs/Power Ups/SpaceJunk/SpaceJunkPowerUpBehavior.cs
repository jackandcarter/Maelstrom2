using UnityEngine;

public class SpaceJunkPowerUpBehavior : MonoBehaviour
{
    public GameObject forceFieldPrefab; // Assign the force field prefab in the inspector.
    private AudioManager audioManager;

    private GameObject activeForceField; // Reference to the active force field instance.

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player collected the SpaceJunk power-up.
            GameObject playerShip = other.gameObject; // Find the player's ship GameObject dynamically.

            // Play the power-up collection sound from AudioManager.
            audioManager.PlaySoundEffect(audioManager.powerUpCollectionSound);

            // Spawn the force field at the player's position.
            if (playerShip != null && forceFieldPrefab != null)
            {
                // Access the player's transform component and position.
                Transform playerTransform = playerShip.transform;
                Vector3 playerPosition = playerTransform.position;

                activeForceField = Instantiate(forceFieldPrefab, playerPosition, Quaternion.identity);

                // Parent the force field to the player to move with them.
                activeForceField.transform.parent = playerTransform;
            }

            // Disable the SpaceJunk power-up object.
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the player's force field has no more collisions.
        if (activeForceField != null && !activeForceField.GetComponent<ForceField>().IsColliding())
        {
            // The player's force field has no more collisions, so destroy it.

            // Play the power-up destroyed sound from AudioManager.
            audioManager.PlaySoundEffect(audioManager.powerUpDestroyedSound);

            Destroy(activeForceField);
        }
    }
}
