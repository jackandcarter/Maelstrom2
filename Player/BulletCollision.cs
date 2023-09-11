using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private float distanceTraveled = 0f;
    private float maxDistance = 10f; // Set your desired maximum distance here.
    private BulletTypes.BulletType bulletType; // Added to store the bullet type.

    // Function to set the bullet type.
    public void SetBulletType(BulletTypes.BulletType type)
    {
        bulletType = type;
    }

    private void Update()
    {
        // Move the bullet forward.
        float distanceMoved = Time.deltaTime * GetComponent<Rigidbody2D>().velocity.magnitude;
        distanceTraveled += distanceMoved;

        // Check if the bullet has traveled beyond its maximum distance.
        if (distanceTraveled >= maxDistance)
        {
            DestroyBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet has collided with an asteroid.
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Destroy the bullet when it hits an asteroid.
            DestroyBullet();
        }
    }

    // Function to set the maximum distance the bullet can travel.
    public void SetDistance(float distance)
    {
        maxDistance = distance;
    }

    // Function to destroy the bullet.
    private void DestroyBullet()
    {
        // Return the bullet to the pool or destroy it as needed.
        BulletManager.Instance.ReturnBullet(bulletType, gameObject);
    }
}
