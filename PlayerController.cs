using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour, IScreenWrappable
{
    public float thrustForce = 5f;
    public float rotationSpeed = 180f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public string fireInput = "Fire1";  // Change this according to your setup
    public string thrustInput = "Vertical";  // Change this according to your setup
    public string rotationInput = "Horizontal";  // Change this according to your setup
    public string shieldInput = "Shield";  // Change this according to your setup
    public ParticleSystem shieldParticleEffect; // Reference to the shield particle effect
    public float shieldDuration = 5f;
    private bool isShieldActive = false;

    private void Update()
    {
        HandleThrust();
        HandleRotation();
        HandleFire();
        HandleShield();

        // Screen wrapping logic
        WrapAroundScreen();
    }

    private void HandleThrust()
    {
        float thrustValue = Input.GetAxis(thrustInput);
        Vector3 thrustDirection = transform.up * thrustValue;
        GetComponent<Rigidbody2D>().AddForce(thrustDirection * thrustForce);
    }

    private void HandleRotation()
    {
        float rotationInputValue = Input.GetAxis(rotationInput);
        transform.Rotate(Vector3.forward, rotationInputValue * rotationSpeed * Time.deltaTime);
    }

    private void HandleFire()
    {
        if (Input.GetButtonDown(fireInput))
        {
            GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = transform.up * bulletSpeed;
            Destroy(newBullet, 3f);
        }
    }

    private void HandleShield()
    {
        if (Input.GetButton(shieldInput) && !isShieldActive)
        {
            StartCoroutine(ActivateShield());
        }
    }

    private IEnumerator ActivateShield()
    {
        isShieldActive = true;
        shieldParticleEffect.Play(); // Play the particle effect
        yield return new WaitForSeconds(shieldDuration);
        shieldParticleEffect.Stop(); // Stop the particle effect
        isShieldActive = false;
    }

    public void WrapAroundScreen()
    {
        // Get the player's current position
        Vector3 currentPosition = transform.position;

        // Check if the player is off-screen to the right
        if (currentPosition.x > ScreenUtils.ScreenRight)
        {
            // Reposition the player to the left side of the screen
            currentPosition.x = ScreenUtils.ScreenLeft;
        }
        // Check if the player is off-screen to the left
        else if (currentPosition.x < ScreenUtils.ScreenLeft)
        {
            // Reposition the player to the right side of the screen
            currentPosition.x = ScreenUtils.ScreenRight;
        }

        // Check if the player is off-screen above
        if (currentPosition.y > ScreenUtils.ScreenTop)
        {
            // Reposition the player to the bottom of the screen
            currentPosition.y = ScreenUtils.ScreenBottom;
        }
        // Check if the player is off-screen below
        else if (currentPosition.y < ScreenUtils.ScreenBottom)
        {
            // Reposition the player to the top of the screen
            currentPosition.y = ScreenUtils.ScreenTop;
        }

        // Update the player's position
        transform.position = currentPosition;
    }
}
