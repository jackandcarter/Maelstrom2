using UnityEngine;

public class SpaceMine : MonoBehaviour
{
    public int damageAmount = 1;  // Adjust damage as needed.
    public float hoverSpeed = 1f;  // Adjust the hover speed.
    public float rotationSpeed = 30f;  // Adjust the rotation speed.

    private float hoverOffset = 0f;

    private void Start()
    {
        // Randomize the starting hover offset to avoid uniform movement.
        hoverOffset = Random.Range(0f, Mathf.PI * 2f);
    }

    private void Update()
    {
        // Apply a hovering effect using Mathf.Sin.
        float hoverHeight = Mathf.Sin((Time.time + hoverOffset) * hoverSpeed) * 0.1f;  // Adjust amplitude (0.1f) as needed.
        transform.Translate(Vector3.up * hoverHeight * Time.deltaTime, Space.World);

        // Rotate the mine.
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle player damage.
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Destroy the mine upon contact with the player.
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            // Destroy the mine upon being hit by a bullet.
            Destroy(gameObject);
        }
    }
}
