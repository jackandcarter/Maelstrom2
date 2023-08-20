using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 5f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ApplyRandomMovement();
    }

    void ApplyRandomMovement()
    {
        // Randomly choose a direction (left or right)
        int direction = Random.Range(0, 2) == 0 ? -1 : 1;

        // Random speed within the specified range
        float speed = Random.Range(minSpeed, maxSpeed);

        // Apply a force to the asteroid to make it move in the chosen direction
        rb.velocity = new Vector3(direction * speed, 0f, 0f);

        // Randomly rotate the asteroid to give it a different initial direction
        Vector3 randomRotation = new Vector3(0f, 0f, Random.Range(0f, 360f));
        transform.Rotate(randomRotation);
    }
}
