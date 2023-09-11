using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrustForce = 5f;
    public float rotationSpeed = 180f;
    public float maxVelocity = 10f;

    private Rigidbody2D rb;
    private bool hasSpaceJunkPowerUp = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }

    private void Update()
    {
        float thrustInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        Vector2 thrust = transform.up * thrustForce * thrustInput;
        rb.AddForce(thrust);

        float rotation = -rotationInput * rotationSpeed * Time.deltaTime;
        rb.rotation += rotation;

        // Limit the player's velocity to prevent excessive speed.
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }

    public void ApplySpaceJunkPowerUp()
    {
        hasSpaceJunkPowerUp = true;
        // You can also set a timer to disable the effect after a certain duration if needed.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasSpaceJunkPowerUp)
        {
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Asteroid") ||
                collision.gameObject.CompareTag("BlackHole") || collision.gameObject.CompareTag("SuperNova") ||
                collision.gameObject.CompareTag("EnemyBullet"))
            {
                // Handle collision without taking damage.
                // You can add visual effects or other logic here.
                hasSpaceJunkPowerUp = false; // Disable the effect after a collision.
            }
        }
        else
        {
            // Handle normal collision logic (player takes damage, loses a life, etc.).
            // Example: Reduce player health, play damage effects, etc.

            // Instead of setting angular velocity to zero, you can reset the rotation directly.
            transform.rotation = Quaternion.identity; // Reset rotation to zero.
        }
    }
}
