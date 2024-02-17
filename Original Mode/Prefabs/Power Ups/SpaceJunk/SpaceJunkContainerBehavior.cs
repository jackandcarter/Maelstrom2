using UnityEngine;

public class SpaceJunkContainerBehavior : MonoBehaviour
{
    public GameObject spaceJunkPowerUpPrefab; // Assign the SpaceJunk PowerUp prefab in the inspector.
    public float rotationSpeed = 30f;
    public int hitPoints = 3; // Number of hits required to destroy the container

    private AudioManager audioManager;

    private void Start()
    {
        // Start rotating the container.
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Get a reference to the AudioManager.
        audioManager = AudioManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            // Reduce hit points.
            hitPoints--;

            if (hitPoints <= 0)
            {
                // Spawn SpaceJunk PowerUp in the container's position.
                Instantiate(spaceJunkPowerUpPrefab, transform.position, Quaternion.identity);
                audioManager.PlaySoundEffect(audioManager.spaceJunkSound);

                // Destroy the container.
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        // Continue rotating the container.
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
