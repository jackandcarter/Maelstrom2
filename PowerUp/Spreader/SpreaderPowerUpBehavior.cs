using UnityEngine;

public class SpreaderPowerUpBehavior : MonoBehaviour
{
    public int bulletCount = 4; // Number of bullets to fire per shot.
    public float spreadAngle = 30f; // Spread angle between bullets in degrees.
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
                // Play the power-up collection sound from AudioManager.
                audioManager.PlaySoundEffect(audioManager.powerUpCollectionSound);

                playerAmmo.ActivateSpreaderPowerUp(bulletCount, spreadAngle);
                Destroy(gameObject);
            }
        }
    }
}
