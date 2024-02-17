using UnityEngine;

public class RepeaterPowerUpBehavior : MonoBehaviour
{
    public float fireRateIncrease = 2f; // Fire rate increase per second.
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAmmo playerAmmo = collision.GetComponent<PlayerAmmo>();

            if (playerAmmo != null)
            {
                // Handle power-up collection logic here.
                playerAmmo.ActivateRepeaterPowerUp(fireRateIncrease);

                // Play the power-up collection sound from AudioManager.
                audioManager.PlaySoundEffect(audioManager.powerUpCollectionSound);

                // Destroy the power-up GameObject since it's collected.
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("PlayerBullet") || collision.CompareTag("EnemyBullet") ||
                 collision.CompareTag("BlackHole") || collision.CompareTag("SuperNova"))
        {
            // Handle power-up destruction logic here.
            DestroyPowerUp();
        }
    }

    // Add any additional methods or logic specific to this power-up here.

    private void DestroyPowerUp()
    {
        // Play the power-up destroyed sound from AudioManager.
        audioManager.PlaySoundEffect(audioManager.powerUpDestroyedSound);

        // Destroy the power-up GameObject.
        Destroy(gameObject);
    }
}
