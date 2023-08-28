using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletLifeTime = 2f;
    public float bulletRange = 10f;
    public LayerMask destroyableObjects;

    private float lifeTimer = 0f;
    private Vector2 initialPosition;

    // Speed multiplier for the bullet
    private float speedMultiplier = 1f;
    private float bulletMultiplier = 1f; // New property to adjust bullet speed

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move the bullet
        Vector3 movement = transform.up * (bulletSpeed * speedMultiplier) * Time.deltaTime;

        // Screen wrap logic for bullets
        ScreenWrapObject.WrapObject(transform, Camera.main);

        transform.Translate(movement);

        // Track the bullet's lifespan
        lifeTimer += Time.deltaTime;

        // Destroy the bullet if it exceeds its range or lifespan
        if (Vector2.Distance(initialPosition, transform.position) >= bulletRange || lifeTimer >= bulletLifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collided with a destroyable object
        if ((destroyableObjects.value & 1 << other.gameObject.layer) != 0)
        {
            Destroy(other.gameObject); // Destroy the other object
            Destroy(gameObject); // Destroy the bullet
        }
    }

    // Method to set the bullet count for spreading
    public void SetBulletCount(int count)
    {
        bulletMultiplier = count; // Set bullet multiplier
    }

    // Method to spread bullets in a cone
    public void SpreadBullets(float spreadAngle)
    {
        // Calculate the spread angle between bullets
        float angleStep = spreadAngle / (bulletMultiplier - 1); // Use bullet multiplier

        // Calculate the initial rotation of the first bullet
        float initialRotation = -spreadAngle / 2f;

        for (int i = 0; i < bulletMultiplier; i++) // Use bullet multiplier
        {
            // Instantiate a bullet with the current rotation
            Quaternion rotation = Quaternion.Euler(0f, 0f, initialRotation + i * angleStep);
            GameObject bullet = Instantiate(gameObject, transform.position, rotation);
            BulletController bulletController = bullet.GetComponent<BulletController>();

            // Set bullet properties
            bulletController.bulletSpeed = bulletSpeed;
            bulletController.bulletLifeTime = bulletLifeTime;
            bulletController.bulletRange = bulletRange;
            bulletController.speedMultiplier = speedMultiplier; // Set speed multiplier
        }

        // Destroy the original bullet
        Destroy(gameObject);
    }

    // Method to set the speed multiplier for the bullet
    public void SetBulletSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }

    // Method to set bullet properties including speed and multiplier
    public void SetBulletProperties(float speedMultiplier, float bulletMultiplier)
    {
        this.speedMultiplier = speedMultiplier;
        this.bulletMultiplier = bulletMultiplier;
    }
}
