using UnityEngine;
using UnityEngine.UI;

public class ForceField : MonoBehaviour
{
    public float outwardForce = 10f; // Adjust the force strength as needed.
    public float forceFieldDuration = 5f; // Adjust the duration of the force field.
    public Image forceFieldIcon; // Assign the UI icon for the force field in the inspector.

    private bool isColliding = false; // Flag to track collisions.

    private void Start()
    {
        // Activate the UI icon for the force field.
        ActivateForceFieldUI();

        // Apply an outward force to nearby objects using 2D physics.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Enemy")) // Adjust the tag as needed.
            {
                Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 forceDirection = (col.transform.position - transform.position).normalized;
                    rb.AddForce(forceDirection * outwardForce, ForceMode2D.Impulse);
                }
            }
        }

        // Schedule the force field to deactivate after a certain duration.
        Invoke("DeactivateForceField", forceFieldDuration);
    }

    private void DeactivateForceField()
    {
        // Deactivate the UI icon for the force field.
        DeactivateForceFieldUI();

        // Mark that the force field is colliding.
        isColliding = true;

        // Destroy the force field.
        Destroy(gameObject);
    }

    public bool IsColliding()
    {
        return isColliding;
    }

    private void ActivateForceFieldUI()
    {
        // Activate the UI icon for the force field.
        if (forceFieldIcon != null)
        {
            forceFieldIcon.gameObject.SetActive(true);
        }
    }

    private void DeactivateForceFieldUI()
    {
        // Deactivate the UI icon for the force field.
        if (forceFieldIcon != null)
        {
            forceFieldIcon.gameObject.SetActive(false);
        }
    }
}
