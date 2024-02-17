using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    public float thrustForce = 10f;
    public float maxVelocity = 20f;
    public float rotationSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Rotate the ship and change the facing direction based on mouse movement
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX);
        transform.Rotate(Vector3.right, -mouseY);

        // Apply thrust and move the ship in the direction it's facing with the W key
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * thrustForce, ForceMode.Acceleration);
        }

        // Limit velocity
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }
}
