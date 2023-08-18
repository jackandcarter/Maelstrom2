using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject shield;
    public int maxShieldDuration = 5;

    public Animator animator;
    public float respawnTime = 2f;

    private bool isInvincible = false;
    private float shieldTimer;
    private int currentShieldDuration;
    private int lives = 3;
    private Vector3 respawnPosition;
    private AmmoType currentAmmoType = AmmoType.Normal;

    private enum AmmoType
    {
        Normal,
        Spreader,
        Repeater,
        LongRange
    }

    private void Start()
    {
        currentShieldDuration = maxShieldDuration;
        respawnPosition = transform.position;
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Move();
        Fire();
        UpdateShield();
    }

    private void ProcessInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Move();
        Rotate();
        Fire();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed * Time.fixedDeltaTime;
        transform.Translate(movement);
    }

    private void Rotate()
    {
        float rotation = -Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.forward * rotation);
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentAmmoType)
            {
                case AmmoType.Normal:
                    FireBullet();
                    break;
                case AmmoType.Spreader:
                    FireSpreader();
                    break;
                case AmmoType.Repeater:
                    FireRepeater();
                    break;
                case AmmoType.LongRange:
                    FireLongRange();
                    break;
            }
        }
    }

    private void FireBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void FireSpreader()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, firePoint.eulerAngles.z + 15f));
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, firePoint.eulerAngles.z - 15f));
    }

    private void FireRepeater()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void FireLongRange()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, firePoint.eulerAngles.z + 5f));
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, firePoint.eulerAngles.z - 5f));
    }

    private void UpdateShield()
    {
        if (isInvincible)
        {
            shield.SetActive(true);
            shieldTimer += Time.deltaTime;

            if (shieldTimer >= 1f)
            {
                currentShieldDuration--;
                shieldTimer = 0f;

                if (currentShieldDuration <= 0)
                {
                    DisableShield();
                }
            }
        }
        else
        {
            shield.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            PowerUp powerUp = collision.GetComponent<PowerUp>();
            CollectPowerUp(powerUp.type);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("EnemyBullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject);

            if (!isInvincible)
            {
                LoseLife();

                if (lives <= 0)
                {
                    GameManager.instance.EndGame();
                }
                else
                {
                    StartCoroutine(RespawnPlayer());
                }
            }
        }
    }

    private void CollectPowerUp(PowerUp.PowerUpType type)
    {
        switch (type)
        {
            case PowerUp.PowerUpType.AmmoUpgrade:
                UpgradeAmmo();
                break;
            case PowerUp.PowerUpType.ShieldRefill:
                ActivateShield();
                break;
        }
    }

    private void UpgradeAmmo()
    {
        switch (currentAmmoType)
        {
            case AmmoType.Normal:
                currentAmmoType = AmmoType.Spreader;
                break;
            case AmmoType.Spreader:
                currentAmmoType = AmmoType.Repeater;
                break;
            case AmmoType.Repeater:
                currentAmmoType = AmmoType.LongRange;
                break;
            case AmmoType.LongRange:
                // No further upgrades
                break;
        }
    }

    private void ActivateShield()
    {
        isInvincible = true;
        currentShieldDuration = maxShieldDuration;
    }

    private void DisableShield()
    {
        isInvincible = false;
    }

    private void TakeDamage()
    {
        if (!isInvincible)
        {
            lives--;
            animator.SetTrigger("Death");
        }
    }

    private void LoseLife()
    {
        GameManager.instance.UpdateLivesUI(lives);
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnTime);
        animator.SetTrigger("Respawn");
        transform.position = respawnPosition;
        isInvincible = true;
        yield return new WaitForSeconds(respawnTime);
        isInvincible = false;
    }
}
