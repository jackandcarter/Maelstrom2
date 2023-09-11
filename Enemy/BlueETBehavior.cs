using UnityEngine;

public class BlueETBehavior : MonoBehaviour
{
    // Define the waypoints for this craft in the Inspector.
    public Transform[] waypoints;
    public float moveSpeed = 10f;
    public float bulletDodgeDistance = 2f;
    public int maxBulletHits = 3;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootingCooldown = 1f;

    private int currentWaypointIndex = 0;
    private Transform player;
    private int bulletHits = 0;
    private bool canShoot = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("ShootAtPlayer", 0f, shootingCooldown);
    }

    private void Update()
    {
        if (bulletHits >= maxBulletHits)
        {
            Destroy(gameObject);
            return;
        }

        CheckBulletDodging();

        Transform safeWaypoint = FindSafeWaypoint();
        Transform bestShootingWaypoint = FindBestShootingWaypoint();
        
        CalculatePathToWaypoint(safeWaypoint);
        MoveTowardsWaypoint(safeWaypoint);
        RotateTowardsWaypoint(bestShootingWaypoint);
    }

    private void CheckBulletDodging()
    {
        // Implement bullet dodging logic here.
    }

    private Transform FindSafeWaypoint()
    {
        // Implement logic to find the safest waypoint here.
    }

    private Transform FindBestShootingWaypoint()
    {
        // Implement logic to find the best shooting waypoint here.
    }

    private void CalculatePathToWaypoint(Transform waypoint)
    {
        // Implement pathfinding logic here.
    }

    private void MoveTowardsWaypoint(Transform waypoint)
    {
        // Implement movement logic here.
    }

    private void RotateTowardsWaypoint(Transform waypoint)
    {
        // Implement rotation logic here.
    }

    private void ShootAtPlayer()
    {
        if (canShoot)
        {
            if (bulletPrefab != null && bulletSpawnPoint != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                // Set bullet behavior (movement, damage, etc.).
                // Tag the bullet as "EnemyBullet".
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                if (bulletRb != null)
                {
                    bulletRb.velocity = transform.up * bulletSpeed;
                }
            }
        }
    }
}
