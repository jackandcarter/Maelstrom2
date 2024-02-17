using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float bulletDistance = 10f;
    public float fireRate = 0.5f;

    public BulletTypes.BulletType currentBulletType; // Updated to store the current bullet type.
    
    // Power-up prefabs
    public GameObject repeaterPrefab;
    public GameObject spreaderPrefab;
    public GameObject homingMissilePrefab;
    public GameObject longRangePrefab;

    // Variables to store power-up effects
    private float repeaterFireRateMultiplier = 1f;
    private int spreaderBulletCount = 1;
    private float spreaderSpreadAngle = 0f;
    private float longRangeDistanceIncrease = 0f;
    private bool homingMissileActive = false;

    private float lastFireTime;

    private void Start()
    {
        // Initialize the currentBulletType with the default bullet type.
        currentBulletType = BulletTypes.BulletType.Normal;
    }

    private void Update()
    {
        // Handle regular shooting logic here.
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) && Time.time > lastFireTime + GetFireRate())
        {
            Shoot();
            lastFireTime = Time.time;

            // Play the Player Bullet Sound clip from the audio manager when shooting.
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.playerBulletSound);
        }

        // Check if the Repeater power-up is active.
        if (repeaterFireRateMultiplier > 1f)
        {
            // Implement Repeater power-up logic here.
            // Increase fire rate.
            // ...
        }

        // Check if the Spreader power-up is active.
        if (spreaderBulletCount > 1)
        {
            // Implement Spreader power-up logic here.
            // Adjust bullet spread.
            // ...
        }

        // Check if the LongRange power-up is active.
        if (longRangeDistanceIncrease > 0f)
        {
            // Implement LongRange power-up logic here.
            // Increase bullet distance.
            // ...
        }

        // Check if the HomingMissile power-up is active.
        if (homingMissileActive)
        {
            // Implement HomingMissile power-up logic here.
            // Make bullets seek targets.
            // ...
        }

        // Align bulletSpawnPoint with the ship's rotation
        bulletSpawnPoint.rotation = transform.rotation;
    }

    // Function to calculate fire rate with power-up effect.
    private float GetFireRate()
    {
        return fireRate / repeaterFireRateMultiplier;
    }

    // Function to shoot a bullet.
    private void Shoot()
    {
        // Instead of instantiating a new bullet, get a bullet from the pool.
        GameObject bullet = BulletManager.Instance.GetBullet(currentBulletType); // Pass the current bullet type.

        // Set the tag of the instantiated bullet.
        bullet.tag = "PlayerBullet";

        // Set the position and rotation.
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.rotation = bulletSpawnPoint.rotation;

        // Calculate the direction in which the bullet should be shot based on the ship's rotation angle.
        Vector2 shootDirection = bulletSpawnPoint.up; // Assuming bulletSpawnPoint's local up vector points forward.

        // Set the velocity.
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * bulletSpeed;

        // Set the bullet distance and return it to the pool when it's out of range.
        BulletCollision bulletCollision = bullet.GetComponent<BulletCollision>();
        if (bulletCollision != null)
        {
            bulletCollision.SetBulletType(currentBulletType); // Set the bullet type.
            bulletCollision.SetDistance(bulletDistance);
        }
    }


    // Function to activate the Repeater power-up.
    public void ActivateRepeaterPowerUp(float fireRateIncrease)
    {
        repeaterFireRateMultiplier = fireRateIncrease;
    }

    // Function to activate the Spreader power-up.
    public void ActivateSpreaderPowerUp(int bulletCount, float spreadAngle)
    {
        spreaderBulletCount = bulletCount;
        spreaderSpreadAngle = spreadAngle;
    }

    // Function to activate the LongRange power-up.
    public void ActivateLongRangePowerUp(float distanceIncrease)
    {
        longRangeDistanceIncrease = distanceIncrease;
    }

    // Function to activate the HomingMissile power-up.
    public void ActivateHomingMissilePowerUp()
    {
        homingMissileActive = true;
    }

    // Function to set the current bullet type based on the collected power-up.
    public void SetCurrentBulletType(BulletTypes.BulletType bulletType)
    {
        currentBulletType = bulletType;
    }
}
