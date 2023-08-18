using UnityEngine;

public class SuperNovaEvent : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Asteroid asteroid = collision.GetComponent<Asteroid>();
            asteroid.TakeDamage();

            Rigidbody2D asteroidRigidbody = collision.GetComponent<Rigidbody2D>();
            asteroidRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            Destroy(gameObject);
        }
    }
}
