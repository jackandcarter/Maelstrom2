using UnityEngine;

public class BlackHoleBehavior : MonoBehaviour
{
    public float pullRadius = 5f; // Radius within which objects are pulled.
    public float pullForce = 10f; // Force at which objects are pulled.
    public float spinSpeed = 50f; // Rotation speed of the black hole.

    public GameObject innerCollider; // Reference to the inner collider for player death.

    private bool canPull = true; // Flag to control force application

    private void Start()
    {
        if (innerCollider != null)
        {
            Collider2D innerCircleCollider = innerCollider.GetComponent<Collider2D>();
            if (innerCircleCollider != null)
            {
                innerCircleCollider.isTrigger = true;
            }
        }
    }

    private void Update()
    {
        // Rotate the black hole clockwise.
        transform.Rotate(Vector3.back * spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle player death when they collide with the inner collider.
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Adjust damage or handle player death logic.
            }

            // Disable further pulling for a brief period
            canPull = false;
            Invoke("EnablePulling", 1f); // Adjust the cooldown duration as needed
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (canPull)
        {
            // Apply pulling force to objects within the pull radius.
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = transform.position - other.transform.position;
                float distance = forceDirection.magnitude;

                if (distance > 0 && distance <= pullRadius)
                {
                    float forceMagnitude = pullForce / distance;
                    Vector2 force = forceDirection.normalized * forceMagnitude;

                    rb.AddForce(force);

                    // Scale down objects as they get closer to the black hole.
                    float scale = Mathf.Lerp(1f, 0.1f, distance / pullRadius);
                    other.transform.localScale = new Vector3(scale, scale, 1f);
                }
            }
        }
    }

    private void EnablePulling()
    {
        canPull = true;
    }
}
