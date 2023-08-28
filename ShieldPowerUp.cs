using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float shieldDuration = 10.0f; // Shield duration in seconds

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ActivateShield(shieldDuration);
                Destroy(gameObject);
            }
        }
    }
}
