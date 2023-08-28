using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this speed as needed
    public float rotationSpeed = 180f; // Adjust this speed as needed
    public GameObject bulletPrefab; // Assign the bullet prefab in the Inspector
    public Transform bulletSpawnPoint; // Assign the bullet spawn point in the Inspector
    public float shieldPoints = 100f; // Initial shield points

    private bool isShieldActive = false; // Flag to track if the shield is active
    private bool isRepeaterActive = false; // Flag to track if the repeater power-up is active
    private bool isLongRangeActive = false; // Flag to track if the long-range power-up is active
    private bool isSpreaderActive = false; // Flag to track if the spreader power-up is active

    // Power-up properties
    private float longRangeMultiplier = 1f;
    private int spreaderBulletCount = 1;
    
    void Update()
    {
        // Player rotation logic
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * -rotationInput * rotationSpeed * Time.deltaTime);

        // Player thrust logic
        float thrustInput = Input.GetAxis("Vertical");
        Vector3 forwardDirection = transform.up;

        // Apply thrust force in the forward direction
        transform.Translate(forwardDirection * moveSpeed * thrustInput * Time.deltaTime);

        // Fire bullets logic
        if (Input.GetButtonDown("Fire1"))
        {
            if (isSpreaderActive)
            {
                FireSpreaderBullet();
            }
            else
            {
                FireBullet();
            }
        }

        // Activate and deactivate shield logic
        if (Input.GetButton("Shield"))
        {
            ActivateShield();
        }
        else
        {
            DeactivateShield();
        }

        // Update shield points
        if (isShieldActive)
        {
            shieldPoints -= Time.deltaTime * 5f; // Deplete shield points over time
            if (shieldPoints <= 0f)
            {
                DeactivateShield();
            }
        }
    }

    void FireBullet()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            // Instantiate a bullet at the bullet spawn point
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Set properties based on power-ups
            BulletController bulletController = bullet.GetComponent<BulletController>();

            // For Repeater, continuously fire bullets as long as the button is held
            if (isRepeaterActive)
            {
                bulletController.SetBulletSpeedMultiplier(2f);
            }

            // For Long Range, adjust bullet properties
            if (isLongRangeActive)
            {
                bulletController.SetBulletProperties(longRangeMultiplier, 2f);
            }
        }
    }

    void FireSpreaderBullet()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            // Instantiate spreader bullets in a cone
            for (int i = 0; i < spreaderBulletCount; i++)
            {
                Quaternion rotation = bulletSpawnPoint.rotation * Quaternion.Euler(0f, 0f, i * 10f); // Adjust spread angle as needed
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);
                
                // Set properties based on power-ups
                BulletController bulletController = bullet.GetComponent<BulletController>();
                bulletController.SetBulletSpeedMultiplier(1f); // Adjust speed as needed
            }
        }
    }

    void ActivateShield()
    {
        // Activate the shield
        isShieldActive = true;
    }

    void DeactivateShield()
    {
        // Deactivate the shield
        isShieldActive = false;
    }

    public void TakeDamage(float damage)
    {
        if (!isShieldActive)
        {
            // Handle player damage logic here, e.g., reduce player lives
            // You can also implement a respawn mechanism here
        }
    }

    public void ActivateRepeaterPowerUp()
    {
        isRepeaterActive = true;
    }

    public void DeactivateRepeaterPowerUp()
    {
        isRepeaterActive = false;
    }

    public void ActivateLongRangePowerUp(float multiplier)
    {
        isLongRangeActive = true;
        longRangeMultiplier = multiplier;
    }

    public void DeactivateLongRangePowerUp()
    {
        isLongRangeActive = false;
        longRangeMultiplier = 1f;
    }

    public void ActivateSpreaderPowerUp(int bulletCount)
    {
        isSpreaderActive = true;
        spreaderBulletCount = bulletCount;
    }

    public void DeactivateSpreaderPowerUp()
    {
        isSpreaderActive = false;
        spreaderBulletCount = 1;
    }
}
