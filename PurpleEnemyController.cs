using System.Collections;
using UnityEngine;

public class PurpleEnemyController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public int health = 10;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 2.0f;

    private bool canShoot = true;

    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    private void Update()
    {
        // Implement movement logic here.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Implement collision logic here.
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (canShoot)
            {
                Shoot();
                canShoot = false;
                yield return new WaitForSeconds(1.0f / fireRate);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Shoot()
    {
        // Implement bullet spawning logic here.
    }
}
