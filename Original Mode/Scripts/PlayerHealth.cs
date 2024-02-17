using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public float respawnEffectDuration = 2f; // Duration of the respawn effect.
    public float blinkDuration = 2f; // Duration of the blink effect.
    public int maxShieldPoints = 100;
    public float shieldDepletionRate = 5f; // Points per second
    public float shieldRegenerationRate = 10f; // Points per second
    public float shieldCooldownDuration = 10f; // Cooldown duration in seconds
    public KeyCode shieldActivationKey = KeyCode.DownArrow;
    public GameObject shieldEffectPrefab; // Reference to the shield effect prefab.
    public GameObject playerExplosionPrefab; // Reference to the player explosion animation prefab.
    public bool isInputEnabled = true; // Flag to control player input.

    private int currentLives;
    private int currentShieldPoints;
    private float shieldCooldownTimer;
    private bool isRespawning;
    private bool isShieldActive;
    private bool isInvulnerable;
    private GameObject currentShieldEffect; // Reference to the instantiated shield effect GameObject.

    private SpriteRenderer playerRenderer; // Reference to the player's sprite renderer.
    private bool isBlinking; // Flag to control the blink effect.

    public Text livesText; // Reference to the text element for player lives in UI.
    public Image shieldBarImage; // Reference to the shield bar image in UI.

    private void Start()
    {
        currentLives = maxLives;
        currentShieldPoints = maxShieldPoints;
        isRespawning = false;
        isShieldActive = false;
        isInvulnerable = false;
        shieldCooldownTimer = 0f;

        playerRenderer = GetComponent<SpriteRenderer>();
        isBlinking = false;

        // Update the lives text in the UI.
        UpdateLivesText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(shieldActivationKey) && isInputEnabled)
        {
            // Activate shield.
            ActivateShield();
        }
        else if (Input.GetKeyUp(shieldActivationKey))
        {
            // Deactivate shield.
            DeactivateShield();
        }

        if (isShieldActive)
        {
            // Deplete the shield points.
            currentShieldPoints -= Mathf.RoundToInt(shieldDepletionRate * Time.deltaTime);
            if (currentShieldPoints <= 0)
            {
                currentShieldPoints = 0;
                DeactivateShield();
                shieldCooldownTimer = shieldCooldownDuration;
            }
        }
        else
        {
            // Regenerate shield points and handle cooldown.
            if (shieldCooldownTimer > 0f)
            {
                shieldCooldownTimer -= Time.deltaTime;
            }
            else
            {
                currentShieldPoints += Mathf.RoundToInt(shieldRegenerationRate * Time.deltaTime);
                currentShieldPoints = Mathf.Clamp(currentShieldPoints, 0, maxShieldPoints);
            }
        }

        // Update the shield bar UI.
        UpdateShieldBar();

        // Handle blink effect.
        if (isBlinking)
        {
            HandleBlinkEffect();
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvulnerable && !isRespawning)
        {
            if (isShieldActive)
            {
                // Play shield collision effect.
                // Handle shield collision logic here.
            }
            else
            {
                // Handle player collision logic here (losing a life, respawning, etc.).

                currentLives -= damage;

                if (currentLives > 0)
                {
                    // Player still has lives left, respawn.
                    PlayerDeath();
                }
                else
                {
                    // Player has no lives left, handle game over logic.
                    // GameManager.Instance.GameOver(YourCurrentScoreLogic()); // Pass the player's final score.
                    // Handle game over logic here.
                }
            }
        }
    }

    public void PlayerDeath()
    {
        // Disable player input.
        isInputEnabled = false;

        // Handle player explosion animation or effects.
        PlayPlayerExplosionSound(); // Play the player explosion sound.
        isRespawning = true;
        isInvulnerable = true;

        // Stop player's velocity to prevent shooting up in the air.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }

        // Play the player explosion animation.
        PlayPlayerExplosionAnimation();

        // Start the respawn effect (blink).
        StartCoroutine(RespawnEffect());
    }

    private IEnumerator RespawnEffect()
    {
        float startTime = Time.time;
        float endTime = startTime + respawnEffectDuration;

        // Activate the shield during the respawn effect.
        ActivateShield();

        while (Time.time < endTime)
        {
            isBlinking = true;
            yield return new WaitForSeconds(0.2f); // Toggle the sprite visibility every 0.2 seconds.
            playerRenderer.enabled = !playerRenderer.enabled;
        }

        // Ensure the player is visible when the blinking effect ends.
        playerRenderer.enabled = true;
        isBlinking = false;

        // Deactivate the shield after the respawn effect.
        DeactivateShield();

        // Enable player input.
        isInputEnabled = true;

        // Update the lives text in the UI.
        UpdateLivesText();
    }

    private void HandleBlinkEffect()
    {
        // Handle additional logic for the blinking effect here if needed.
        // For example, altering the blink rate, changing colors, etc.
    }

    public void ActivateShield()
    {
        isShieldActive = true;

        // Instantiate the shield effect prefab and attach it to the player.
        if (shieldEffectPrefab != null && currentShieldEffect == null)
        {
            // Instantiate the shield effect prefab at the player's position with the ship's rotation.
            currentShieldEffect = Instantiate(shieldEffectPrefab, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z));

            // Make the shield effect prefab a child of the player to follow its position.
            currentShieldEffect.transform.parent = transform;
        }
    }

    public void DeactivateShield()
    {
        isShieldActive = false;

        // Destroy the shield effect GameObject if it exists.
        if (currentShieldEffect != null)
        {
            Destroy(currentShieldEffect);
            currentShieldEffect = null;
        }
    }

    private void PlayPlayerExplosionSound()
    {
        // Play the Player Explosion Sound clip from the audio manager.
        AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.playerExplosionSound);
    }

    private void PlayPlayerExplosionAnimation()
    {
        // Instantiate the player explosion animation prefab.
        if (playerExplosionPrefab != null)
        {
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
        }
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

    private void UpdateShieldBar()
    {
        if (shieldBarImage != null)
        {
            float fillAmount = (float)currentShieldPoints / maxShieldPoints;
            shieldBarImage.fillAmount = fillAmount;
        }
    }

    public int GetShieldPoints()
    {
        return currentShieldPoints;
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }
}
