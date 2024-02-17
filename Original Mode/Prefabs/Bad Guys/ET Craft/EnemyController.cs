using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyColor { Purple, Green, Blue }
    public EnemyColor enemyColor; // Assign the enemy's color in the Inspector.
    public float movementSpeed = 2f; // Movement speed from left to right.
    public float aggressionLevel = 1f; // Aggression level (1 to 5, 5 being very aggressive).
    public GameObject enemyBulletPrefab; // Assign the enemy bullet prefab.
    public float fireRate = 2f; // Time between shots in seconds.

    public int maxHealth = 3; // Maximum health points.
    public GameObject explosionEffect; // Assign the explosion effect prefab.

    private AudioManager audioManager;
    private float nextFireTime;
    private int currentHealth;

    private void Start()
    {
        audioManager = AudioManager.Instance;
        currentHealth = maxHealth;
        nextFireTime = Time.time + Random.Range(0f, fireRate / 2); // Add random delay for initial shot.
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        // Move the enemy craft from left to right.
        Vector2 newPosition = transform.position + Vector3.right * movementSpeed * Time.deltaTime;
        transform.position = newPosition;

        // Destroy the enemy when it leaves the screen.
        if (!IsVisibleOnScreen())
        {
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        // Check if it's time to fire.
        if (Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + 1f / (fireRate * aggressionLevel);
        }
    }

    private void FireBullet()
    {
        // Instantiate and fire an enemy bullet.
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.left * movementSpeed * aggressionLevel;
        
        // Play the Enemy Bullet sound.
        audioManager.PlaySoundEffect(audioManager.enemyBulletSound);
    }

    private bool IsVisibleOnScreen()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        return (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Play the ET Craft Death sound.
        audioManager.PlaySoundEffect(audioManager.ETCraftDeathSound);

        // Spawn an explosion effect.
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // Destroy the enemy craft.
        Destroy(gameObject);
    }
}
