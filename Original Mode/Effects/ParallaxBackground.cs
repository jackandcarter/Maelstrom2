using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float parallaxSpeed = 0.1f; // Adjust this value to control the parallax speed

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the parallax offset based on the camera's movement
        float parallaxOffset = Camera.main.transform.position.x * parallaxSpeed;

        // Move the background slightly to create the parallax effect
        transform.position = new Vector3(startPosition.x + parallaxOffset, startPosition.y, startPosition.z);
    }
}
