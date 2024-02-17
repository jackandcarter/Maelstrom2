using UnityEngine;

public class _2DPlayerShipController : MonoBehaviour
{
    public float thrust = 10f; // Thrust speed
    public float rotationSpeed = 100f; // Rotation speed
    public float maxVelocity = 20f; // Maximum velocity of the ship

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle rotation input
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back, rotationInput * rotationSpeed * Time.deltaTime);

        // Handle thrust input
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Apply thrust in the ship's forward direction
            Vector2 thrustForce = transform.up * thrust;
            rb.AddForce(thrustForce, ForceMode2D.Force);

            // Limit velocity to the maximum
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
}
