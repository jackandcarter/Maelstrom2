using UnityEngine;

public class ETCraftEnemy : MonoBehaviour
{
    public enum ETCraftType { Purple, Green, Blue }
    public ETCraftType type;
    
    public float movementSpeed = 2f;
    public float fireRate = 2f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    
    private float nextFireTime;
    
    private void Update()
    {
        Move();
        Fire();
    }
    
    private void Move()
    {
        // Implement movement logic based on the ETCraftType
    }
    
    private void Fire()
    {
        if (Time.time > nextFireTime)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + 1 / fireRate;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
