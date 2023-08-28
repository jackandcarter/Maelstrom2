using UnityEngine;

public class GammaRayEvent : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the Gamma Ray
    public LayerMask targetLayers; // Layers that the Gamma Ray can affect
    public float affectRadius = 1.0f; // Radius within which objects are affected

    private void Update()
    {
        // Move the Gamma Ray to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Check for objects within the affectRadius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, affectRadius, targetLayers);

        // Destroy detected objects
        foreach (Collider2D collider in colliders)
        {
            Destroy(collider.gameObject);
        }
    }
}
