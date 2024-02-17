using UnityEngine;

public class GreenETBehavior : MonoBehaviour
{
    // Define the waypoints for this craft in the Inspector.
    public Transform[] waypoints;
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float minDistanceToWaypoint = 0.2f;
    public float shootingCooldown = 2f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float detectionRadius = 5f;

    private int currentWaypointIndex = 0;
    private float shootingTimer = 0f;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        MoveToWaypoint();
        HandleShooting();
    }

    private void MoveToWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        Vector3 targetPosition;

        if (IsPlayerDetected())
        {
            targetPosition = player.position;
        }
        else
        {
            targetPosition = waypoints[currentWaypointIndex].position;

            float distanceToWaypoint = Vector3.Distance(transform.position, targetPosition);
            if (distanceToWaypoint < minDistanceToWaypoint)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }

        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        float step = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.up, moveDirection, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    private void HandleShooting()
    {
        if (shootingTimer <= 0f && IsPlayerDetected())
        {
            Shoot();
            shootingTimer = shootingCooldown;
        }
        else
        {
            shootingTimer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            // Set bullet behavior (movement, damage, etc.).
            // Tag the bullet as "EnemyBullet".
        }
    }

    private bool IsPlayerDetected()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            return distanceToPlayer <= detectionRadius;
        }
        return false;
    }
}
