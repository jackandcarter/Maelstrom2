using UnityEngine;

public class SupernovaEvent : MonoBehaviour
{
    public float growthSpeed = 1f;
    public float explosionForce = 10f;
    public float timeBeforeExplosion = 5f;
    
    // Other variables as before

    private bool isGrowing = true;
    private bool isExploded = false;
    private float explosionTime;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.speed = 1.0f / growthSpeed;
        explosionTime = Time.time + timeBeforeExplosion;
    }

    void Update()
    {
        if (isGrowing)
        {
            Grow();
        }
        else if (!isExploded && Time.time >= explosionTime)
        {
            Explode();
        }
    }

    void Grow()
    {
        // Growth logic as before

        if (Time.time >= explosionTime)
        {
            isGrowing = false;
        }
    }

    void Explode()
    {
        // If the supernova hasn't exploded yet
        if (!isExploded)
        {
            // Play explosion sound
            audioSource.Play();

            // Check if it's hit by a player's bullet
            if (IsHitByPlayerBullet())
            {
                Destroy(gameObject);
            }
            else
            {
                // Apply explosion force to all objects in the supernova radius
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, spriteRenderer.bounds.size.x / 2f);

                foreach (Collider2D collider in colliders)
                {
                    Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();

                    if (rb != null)
                    {
                        Vector2 direction = (rb.transform.position - transform.position).normalized;
                        rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);
                    }
                }

                isExploded = true;
                Destroy(gameObject);
            }
        }
    }

    bool IsHitByPlayerBullet()
    {
        // Check if a player's bullet has hit the supernova
        // Implement your logic to detect player's bullets here
        // For example, check for collisions with player's bullets

        return false; // Change this based on your actual detection logic
    }
}
